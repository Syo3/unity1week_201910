using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Player : ObjectBase {

    #region define
    private readonly float kMoveSpeed = 20.0f;
    #endregion

    #region SerializeField
    [SerializeField, Tooltip("アニメーター")]
    private Animator _animator;
    #endregion

    #region private field
    private Transform _transform;
    private float _animationCount;
    private bool _activeFlg;
    #endregion


    void Update()
    {
        if(_transform == null)return;
        if(!_activeFlg) return;
        if(CheckActiveGoalObject()){
            GoalTargetMove();
        }
        else{
            SearchAnimation();
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void GoalTargetMove()
    {
        var vectorX        = GetActiveDistanceGoalObject().transform.position.x - _transform.position.x;
        if(vectorX > 0.0f){
            _transform.Translate(new Vector3(kMoveSpeed * Time.deltaTime, 0.0f, 0.0f));
            _sprite.flipX = false;
            _animator.Play("Player_MoveRight");

        }
        else if(vectorX < 0.0f){
            _transform.Translate(new Vector3(-kMoveSpeed * Time.deltaTime, 0.0f, 0.0f));
            _sprite.flipX = true;
        }
    }

    private void SearchAnimation()
    {
        _animationCount += Time.deltaTime;
        if(_animationCount > 1.0f){
            _sprite.flipX   = !_sprite.flipX;
            _animationCount = 0.0f;
            _animator.Play("Player_Wait");
        }
    }


    #region protected function
    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Init()
    {
        _transform      = transform;
        _animationCount = 0.0f;
        _activeFlg      = false;
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    protected override void SetCollision(bool flg)
    {
        Debug.Log("set collision:"+flg);
        if(flg){
            _animator.Play("Player_Wait");
            _activeFlg = true;
        }
        else{
            _animator.Play("Player_HideWait");
            _activeFlg = false;
        }
    }
    #endregion

    #region private function
    /// <summary>
    /// アクティブなゴールがあるか判定
    /// </summary>
    /// <returns></returns>
    private bool CheckActiveGoalObject()
    {
        var goalObjectList = _sceneManager.StageGenerateManager.GoalObjectList;
        for(var i = 0; i < goalObjectList.Count; ++i){
            if(goalObjectList[i].ActiveFlg) return true;
        }
        return false;
    }

    /// <summary>
    /// 最も近いゴールを取得
    /// </summary>
    /// <returns></returns>
    private GoalObject GetActiveDistanceGoalObject()
    {
        var goalObjectList = _sceneManager.StageGenerateManager.GoalObjectList;
        return goalObjectList.Where(x => x.ActiveFlg == true).OrderBy(x => Vector3.Distance(_transform.position, x.transform.position)).ToList()[0];
    }
    #endregion
}

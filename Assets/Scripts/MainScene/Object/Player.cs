using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Player : ObjectBase {

    #region define
    private readonly float kMoveSpeed = 30.0f;
    #endregion

    #region SerializeField
    [SerializeField, Tooltip("アニメーター")]
    private Animator _animator;
    [SerializeField, Tooltip("物理")]
    private Rigidbody2D _rigidBody2d;
    #endregion

    #region private field
    private Transform _transform;
    private float _animationCount;
    private bool _activeFlg;
    #endregion

    #region access
    public bool ActiveFlg{
        set{_activeFlg = value;}
    }
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
        StageFallCheck();
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

    /// <summary>
    /// 探すアニメーション
    /// </summary>
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
        _activeFlg = flg;
        _animator.Play( flg ? "Player_Wait" : "Player_HideWait" );
        _rigidBody2d.gravityScale = _activeFlg ? 20.0f : 0.0f;
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

    /// <summary>
    /// 落下チェック
    /// </summary>
    private void StageFallCheck()
    {
        if(!_activeFlg) return;
        if(_transform.position.y < -160.0f){
            _sceneManager.StageGenerateManager.ReStart();
        }
    }
    #endregion
}

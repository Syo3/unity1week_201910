using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(_sceneManager.GoalObject.ActiveFlg){
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
        var goalObject = _sceneManager.GoalObject;
        var vectorX    = goalObject.transform.position.x - _transform.position.x;
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


    #region protected field
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


}

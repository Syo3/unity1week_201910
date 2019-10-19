using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : ObjectBase {

    #region SerializeField
    [SerializeField, Tooltip("当たり判定")]
    private BoxCollider2D _collider;
    [SerializeField, Tooltip("物理")]
    private Rigidbody2D _rigidBody2d;
    [SerializeField, Tooltip("調整用当たり判定")]
    private CircleCollider2D _circleCollider2D;
    [SerializeField, Tooltip("アニメーター")]
    private Animator _animator;
    [SerializeField, Tooltip("アニメーション用こ要素")]
    private SpriteRenderer _child;
    #endregion

    #region private field
    private Coroutine _animationEndCheck;
    private bool _fallFlg;
    #endregion

    protected override void Init()
    {
        _animationEndCheck = null;
        _fallFlg           = false;
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    protected override void SetCollision(bool flg)
    {
        if(_fallFlg) return;
        if(flg){
            _sprite.sprite      = _sceneManager.SpriteManager.FallBlockWhiteASpriteList[0];
            _collider.isTrigger = false;
            _circleCollider2D.isTrigger = false;
            _animator.enabled   = true;
            _child.enabled      = true;
            _sprite.enabled     = false;
            _animator.Play("FallBlock_FallAppeal",0, 0.0f);
            _animationEndCheck = StartCoroutine(AnimationEndCheck());
        }
        else{
            _sprite.sprite        = _sceneManager.SpriteManager.FallBlockWhiteASpriteList[1];
            _collider.isTrigger   = true;
            _circleCollider2D.isTrigger = true;
            _animator.enabled     = false;
            _rigidBody2d.bodyType = RigidbodyType2D.Kinematic;
            _rigidBody2d.velocity = Vector2.zero;
            if(_animationEndCheck != null) StopCoroutine(_animationEndCheck);
        }
    }

    #region private function
    /// <summary>
    /// アニメーション終了判定
    /// </summary>
    /// <returns></returns>
    private IEnumerator AnimationEndCheck()
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        while(stateInfo.normalizedTime < 1.0f){
            yield return null;
            stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        }
        _sprite.enabled       = true;
        _child.enabled        = false;
        _rigidBody2d.bodyType = RigidbodyType2D.Dynamic;
        _animationEndCheck    = null;
        _fallFlg              = true;
    }

    #endregion
}

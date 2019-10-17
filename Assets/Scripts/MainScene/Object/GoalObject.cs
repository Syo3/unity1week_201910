using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : ObjectBase {

    #region SerializeField
    [SerializeField, Tooltip("あたり判定")]
    private BoxCollider2D _collider;
    #endregion

    #region private field
    private bool _activeFlg;
    private bool _goalFlg;
    #endregion

    #region access
    public bool ActiveFlg{
        get{return _activeFlg;}
    }
    #endregion

    protected override void Init()
    {
        _activeFlg = false;
        _goalFlg   = false;
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    protected override void SetCollision(bool flg)
    {
        if(_goalFlg)return;
        if(flg){
            _sprite.sprite = _sceneManager.SpriteManager.GoalWhiteSpriteList[0];
            _activeFlg     = true;
        }
        else{
            _sprite.sprite = _sceneManager.SpriteManager.GoalWhiteSpriteList[1];
            _activeFlg     = false;
        }
    }

    /// <summary>
    /// 当たり判定 ゴール
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(_goalFlg || !_activeFlg || other.gameObject.tag != "Player")return;
        _sprite.enabled = false;
        _goalFlg        = true;
        _sceneManager.StageGenerateManager.AddGoalActiveCount();
    }
}

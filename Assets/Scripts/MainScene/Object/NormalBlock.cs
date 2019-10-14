using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlock : ObjectBase {

    #region SerializeField
    [SerializeField, Tooltip("当たり判定")]
    private BoxCollider2D _collider;
    #endregion

    protected override void Init()
    {

    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    protected override void SetCollision(bool flg)
    {
        if(flg){
            _sprite.sprite      = _sceneManager.SpriteManager.ObjectSpriteList[0];
            _collider.isTrigger = false;
        }
        else{
            _sprite.sprite      = _sceneManager.SpriteManager.ObjectSpriteList[1];
            _collider.isTrigger = true;
        }
    }

}

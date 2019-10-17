using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;
public class ObjectBase : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("スプライト")]
    protected SpriteRenderer _sprite;
    [SerializeField, Tooltip("色情報")]
    protected Const.ColorType _colorType;
    #endregion

    #region protected field
    protected MainSceneManager _sceneManager;
    protected bool _shadowChangeFlg;    // 色が変わるオブジェクトか
    #endregion

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="sceneManager"></param>
    public void Init(MainSceneManager sceneManager)
    {
        _sceneManager    = sceneManager;
        _shadowChangeFlg = true;
        Init();
    }

    /// <summary>
    /// こ要素の初期化
    /// </summary>
    protected virtual void Init()
    {

    }

    /// <summary>
    /// 表示管理
    /// </summary>
    /// <param name="flg"></param>
    public void SetShowFlg(Const.ColorType colorType = Const.ColorType.kNone, bool collisionEnterFlg = false)
    {
        if(!_shadowChangeFlg) return;
        if(collisionEnterFlg){
            if(_colorType == colorType){                
                //_sprite.enabled = true;
                SetCollision(true);
            }
            else{
                SetCollision(false);
            }
        }
        else{
            // if(_colorType != colorType){                
            //     //_sprite.enabled = false;
            //     SetCollision(false);
            // }
        }

        // if(_colorType == colorType){
            
        //     _sprite.enabled = true;
        // }
        // else{
        //     _sprite.enabled = false;
        // }
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    protected virtual void SetCollision(bool flg)
    {

    }
}

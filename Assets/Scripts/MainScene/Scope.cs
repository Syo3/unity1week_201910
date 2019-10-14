using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;

public class Scope : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("")]
    private List<Sprite> _scopeTextureList;
    [SerializeField, Tooltip("スプライト")]
    private SpriteRenderer _sprite;
    [SerializeField, Tooltip("当たり判定")]
    private CircleCollider2D _circleCollider;
    #endregion

    #region private field
    private MainSceneManager _sceneManager;
    private Transform _transformCache;
    private bool _initFlg = false;
    private bool _inputFlg;
    private Const.ColorType _colorType;

    #endregion

    #region public function
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="sceneManager"></param>
    public void Init(MainSceneManager sceneManager)
    {
        _sceneManager   = sceneManager;
        _transformCache = transform;
        _initFlg        = true;
        _inputFlg       = false;
    }
    #endregion

    #region private function
    void Update()
    {
        if(!_initFlg) return;
        KeyCheck();
    }

    /// <summary>
    /// キー入力
    /// </summary>
    private void KeyCheck()
    {
        _inputFlg  = false;
        _colorType = Const.ColorType.kNone; 
        // 左クリック
        if(Input.GetMouseButton(0)){
            _sprite.sprite = _scopeTextureList[0];
            _inputFlg      = true;
            _colorType     = Const.ColorType.kWhite; 
        }
        // 右クリック
        else if(Input.GetMouseButton(1)){
            _sprite.sprite = _scopeTextureList[1];
            _inputFlg      = true;
            _colorType     = Const.ColorType.kBlack;
        }

        if(_inputFlg){
            SetPosition();
        }
        _sprite.enabled         = _inputFlg;
        _circleCollider.enabled = _inputFlg;
    }

    /// <summary>
    /// 座標設定
    /// </summary>
    private void SetPosition()
    {
        var mousePos             = Input.mousePosition;
    	var objPos               = Camera.main.ScreenToWorldPoint( mousePos );
        _transformCache.localPosition = new Vector3(objPos.x , objPos.y, 0.0f);
    }

    /// <summary>
    /// 衝突瞬間
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    //void OnCollisionEnter2D ( Collision2D other )
    {
        Debug.Log("test");
        if(other.gameObject.tag != "ShadowObject" && other.gameObject.tag != "Player")return;

        Debug.Log("衝突");
        var objectBase = other.gameObject.GetComponent<ObjectBase>();
        objectBase.SetShowFlg(_colorType, true);
    }


    /// <summary>
    /// 衝突抜け
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "ShadowObject" && other.gameObject.tag != "Player")return;
        Debug.Log("衝突抜け");
        var objectBase = other.gameObject.GetComponent<ObjectBase>();
        objectBase.SetShowFlg(_colorType, false);
    }
    #endregion

}

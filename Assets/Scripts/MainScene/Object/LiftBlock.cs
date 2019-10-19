using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBlock : ObjectBase {

    #region define
    private float kMoveSpeed = 20.0f;
    private float kWaitSecond = 2.0f;
    private enum State{
        kWait,
        kMove,
    }
    #endregion

    #region SerializeField
    [SerializeField, Tooltip("当たり判定")]
    private BoxCollider2D _collider;
    [SerializeField, Tooltip("")]
    private Rigidbody2D _rigidBody2D;
    #endregion

    #region private field
    private Transform _transform;
    private List<int> _targetYList;
    private int _targetYListKey;
    private float _nowTargetPositionY;
    private float _moveSpeedY;
    private State _state;
    private float _waitCount;
    private bool _initFlg;
    #endregion

    #region protected fucntion
    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Init()
    {
        _transform    = transform;
        var paramList =  _initSettingString.Split(',');
        _targetYList  = new List<int>();
        for(var i = 0; i < paramList.Length; ++i){
            Debug.Log(paramList[i]);
            _targetYList.Add(int.Parse(paramList[i]));
        }
        _targetYListKey     = 0;
        SetTarget();
        _state              = State.kMove;
        _initFlg   = true;
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    protected override void SetCollision(bool flg)
    {
        if(flg){
            _sprite.sprite      = _sceneManager.SpriteManager.LiftBlockWhiteSpriteList[0];
            _collider.isTrigger = false;
        }
        else{
            _sprite.sprite      = _sceneManager.SpriteManager.LiftBlockWhiteSpriteList[1];
            _collider.isTrigger = true;
        }
    }

    void Update()
    {
        if(!_initFlg || _collider.isTrigger) return;
        Debug.Log("update check:"+_state);
        Debug.Log(_moveSpeedY);
        switch(_state){
        case State.kMove:
            CheckDistance();
            break;
        case State.kWait:
            break;
        }
    }
    #endregion

    #region private function
    private void CheckDistance()
    {

        // FIXME:ガタガタする　余裕があれば考える　見栄え悪いし プレイヤーが当たった瞬間こ要素にする？　離れたら外す
        //_rigidBody2D.MovePosition(new Vector2(0.0f, _moveSpeedY * Time.deltaTime)+new Vector2(_transform.position.x, _transform.position.y));
        _transform.Translate(0.0f, (_moveSpeedY * Time.deltaTime), 0.0f);
        if( _moveSpeedY > 0.0f){
            if(_transform.position.y > _nowTargetPositionY){
                ChangeStateWait();
            }
        }
        else{
            if(_transform.position.y < _nowTargetPositionY){
                ChangeStateWait();
            }
        }
    }

    private void ChangeStateWait()
    {
        _transform.position = new Vector3(_transform.position.x, _nowTargetPositionY );
        _state              = State.kWait;
        _targetYListKey     = ++_targetYListKey >= _targetYList.Count ? 0 : _targetYListKey;
        SetTarget();
        StartCoroutine(Wait());
    }

    private void SetTarget()
    {
        _nowTargetPositionY = Common.Const.START_POS_Y+Common.Const.BLOCK_SIZE*_targetYList[_targetYListKey];
        _moveSpeedY         = _transform.position.y < _nowTargetPositionY ? kMoveSpeed : -kMoveSpeed;
    }

    private IEnumerator Wait()
    {
        var savePos = _transform.position;
        _waitCount  = 0.0f;
        while(_waitCount < kWaitSecond){
            yield return null;
            _transform.position = savePos;
            _waitCount         += Time.deltaTime;
        }
        _state = State.kMove;
    }
    #endregion

}

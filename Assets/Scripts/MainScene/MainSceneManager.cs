﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("スコープ")]
    private Scope _scope;
    [SerializeField, Tooltip("")]
    private NormalBlock _normalBlock;
    [SerializeField, Tooltip("")]
    private NormalBlock _normalBlock2;
    [SerializeField, Tooltip("")]
    private GoalObject _goalObject;
    [SerializeField, Tooltip("読み込みスプライト管理")]
    private SpriteManager _spriteManager;
    [SerializeField, Tooltip("プレイヤー")]
    private Player _player;
    [SerializeField, Tooltip("終了演出")]
    private Animator _endEffect;
    #endregion

    #region access
    public SpriteManager SpriteManager{
        get{return _spriteManager;}
    }
    public GoalObject GoalObject{
        get{return _goalObject;}
    }
    #endregion

	// Use this for initialization
	void Start ()
    {
        _scope.Init(this);

        _normalBlock.Init(this);
        _normalBlock2.Init(this);
        _goalObject.Init(this);
        _player.Init(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #region public function

    public void SetEndEffect()
    {
        _endEffect.Play("EndEffect_Start");
    }
    #endregion
}
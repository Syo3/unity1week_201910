using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour {

    #region define
    public enum StageState{
        kStageCreate,
        kStagePlay,
        kStageClear,
    }
    #endregion

    #region SerializeField
    [SerializeField, Tooltip("読み込みスプライト管理")]
    private SpriteManager _spriteManager;
    [SerializeField, Tooltip("終了演出")]
    private Animator _endEffect;
    [SerializeField, Tooltip("ステージ作成")]
    private StageGenerateManager _stageGenerateManager;
    [SerializeField, Tooltip("プレハブ管理")]
    private PrefabManager _prefabManager;
    #endregion

    #region private field
    private StageState _stageState;
    #endregion

    #region access
    public SpriteManager SpriteManager{
        get{return _spriteManager;}
    }
    public PrefabManager PrefabManager{
        get{return _prefabManager;}
    }
    public StageGenerateManager StageGenerateManager{
        get{return _stageGenerateManager;}
    }
    public StageState NowStageState{
        get{return _stageState;}
        set{_stageState = value;}
    }
    #endregion

	// Use this for initialization
	void Start ()
    {
        _stageGenerateManager.Init(this);
        // ステージ作成
        _stageGenerateManager.CreateStage();
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

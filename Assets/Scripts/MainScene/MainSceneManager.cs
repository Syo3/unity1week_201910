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
    [SerializeField, Tooltip("ステージ作成")]
    private StageGenerateManager _stageGenerateManager;
    [SerializeField, Tooltip("プレハブ管理")]
    private PrefabManager _prefabManager;
    [SerializeField, Tooltip("UI管理")]
    private UIManager _uiManager;
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

    /// <summary>
    /// シーン開始
    /// </summary>
	void Start ()
    {
        // ステージ作成
        _stageGenerateManager.Init(this);
        _stageGenerateManager.CreateStage();
        _uiManager.Init(this);
	}
	
    #region public function
    #endregion
}

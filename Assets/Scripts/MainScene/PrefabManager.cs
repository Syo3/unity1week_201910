using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    #region SerializeFiled
    [SerializeField, Tooltip("プレイヤー白")]
    private GameObject _whitePlayerObject;
    [SerializeField, Tooltip("プレイヤー黒")]
    private GameObject _blackPlayerObject;
    [SerializeField, Tooltip("通常ブロック白")]
    private GameObject _whiteNormalBlockObject;
    [SerializeField, Tooltip("通常ブロック黒")]
    private GameObject _blackNormalBlockObject;
    [SerializeField, Tooltip("固定ブロック")]
    private GameObject _fixedBlockObject;
    [SerializeField, Tooltip("通常ゴール白")]
    private GameObject _whiteGoal;
    [SerializeField, Tooltip("通常ゴール黒")]
    private GameObject _blackGoal;
    [SerializeField, Tooltip("リフト白")]
    private GameObject _whiteLiftBlockObject;
    [SerializeField, Tooltip("落下ブロック白タイプA")]
    private GameObject _whiteFallBlockAObject;
    #endregion

    #region access
    public GameObject WhitePlayerObject{
        get{return _whitePlayerObject;}
    }
    public GameObject BlackPlayerObject{
        get{return _blackNormalBlockObject;}
    }
    public GameObject WhiteNormalBlockObject{
        get{return _whiteNormalBlockObject;}
    }
    public GameObject FixedBlockObject{
        get{return _fixedBlockObject;}
    }
    public GameObject WhiteGoalObject{
        get{return _whiteGoal;}
    }
    public GameObject WhiteLiftBlockObject{
        get{return _whiteLiftBlockObject;}
    }
    public GameObject WhiteFallBlockAObject{
        get{return _whiteFallBlockAObject;}
    }
    #endregion
}

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
    public GameObject WhiteGoal{
        get{return _whiteGoal;}
    }
    #endregion
}

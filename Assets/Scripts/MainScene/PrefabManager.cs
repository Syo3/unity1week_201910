using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    #region SerializeFiled
    [SerializeField, Tooltip("プレイヤー")]
    private GameObject _whitePlayerObject;
    [SerializeField, Tooltip("通常ブロック白")]
    private GameObject _whiteNormalBlockObject;
    [SerializeField, Tooltip("固定ブロック")]
    private GameObject _fixedBlockObject;
    [SerializeField, Tooltip("通常ゴール白")]
    private GameObject _whiteGoal;
    #endregion

    #region access
    public GameObject WhitePlayerObject{
        get{return _whitePlayerObject;}
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

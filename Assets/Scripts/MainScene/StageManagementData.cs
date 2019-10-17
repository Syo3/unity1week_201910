using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagementData : MonoBehaviour {

    #region public field
    public int _backgroundColorType;
    public int _goalCount;
    #endregion

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="backGroundColorType"></param>
    /// <param name="goalCount"></param>
    public StageManagementData(int backGroundColorType, int goalCount)
    {
        _backgroundColorType = backGroundColorType;
        _goalCount           = goalCount;
    }
}

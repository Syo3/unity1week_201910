using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;

public class StageData : MonoBehaviour {

    #region private field
    public Common.Const.ObjectType _type;
    public int _posX;
    public int _posY;
    #endregion

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="type"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    public StageData(Common.Const.ObjectType type, int posX, int posY)
    {
        _type = type;
        _posX = posX;
        _posY = posY;
    }
}

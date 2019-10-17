using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;
public class StageDataManager : MonoBehaviour {

    /// <summary>
    /// ステージデータ取得
    /// </summary>
    /// <param name="stageID"></param>
    /// <returns></returns>
    public static List<StageData> GetStageData(int stageID)
    {
        var stageData = new List<StageData>();
        switch(stageID){
        case 1:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 5, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            break;
        case 2:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 5, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            break;
        }
        return stageData;
    }

    /// <summary>
    /// ステージ管理データ取得
    /// </summary>
    /// <param name="stageID"></param>
    /// <returns></returns>
    public static StageManagementData GetStageManagementData(int stageID)
    {
        switch(stageID){
        case 1:
            return new StageManagementData(1, 1);
        case 2:
            return new StageManagementData(1, 1);
        }
        return null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;
public class StageDataManager : MonoBehaviour {

    public static List<StageData> GetStageData(int stageID)
    {
        var stageData = new List<StageData>();
        switch(stageID){
        case 1:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 5));

            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 5, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 4));
            break;
        }
        return stageData;
    }
}

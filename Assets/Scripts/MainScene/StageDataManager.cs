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
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 3));
            break;
        case 2:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 4));

            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 3));
            break;
        case 3:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 6));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 4));

            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 5));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 7, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 5));
            break;
        case 4:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 4));

            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 4, Const.ColorType.kWhite));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 3));
            break;
        case 5:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 5));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 4));

            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 4, Const.ColorType.kWhite));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 7, 3));


            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 6));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 5));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 2));
            break;
        case 6:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 5));

            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kLiftBlockWhite, 5, 3, Const.ColorType.kNone, "4,3"));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 7, 4));
            break;
        case 7:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kLiftBlockWhite, 4, 3, Const.ColorType.kNone, "4,3"));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 5, Const.ColorType.kWhite));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 5));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 7, 5));
            stageData.Add(new StageData(Common.Const.ObjectType.kLiftBlockWhite, 7, 4, Const.ColorType.kNone, "7,4"));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 8, 7));
            break;
        // 落下ブロックのチュートリアル
        case 8:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 6, 4));

            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 3, Const.ColorType.kWhite));
            stageData.Add(new StageData(Common.Const.ObjectType.kFallBlockWhiteA, 5, 7, Const.ColorType.kWhite));
            break;
        // スポポポ　って感じ
        case 9:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 7, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 2));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 2));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 6, 2));
            stageData.Add(new StageData(Common.Const.ObjectType.kFallBlockWhiteA, 4, 7));
            stageData.Add(new StageData(Common.Const.ObjectType.kFallBlockWhiteA, 5, 7));
            stageData.Add(new StageData(Common.Const.ObjectType.kFallBlockWhiteA, 6, 7));

            break;
        // 今まで全部使って考えさせてみる
        case 10:
            stageData.Add(new StageData(Common.Const.ObjectType.kPlayerWhite, 3, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kGoalWhite, 7, 5));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 7, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 8, 3, Const.ColorType.kWhite));


            stageData.Add(new StageData(Common.Const.ObjectType.kLiftBlockWhite, 3, 2, Const.ColorType.kNone, "3,2"));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 3));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 2));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 4));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 4, 5));

            stageData.Add(new StageData(Common.Const.ObjectType.kLiftBlockWhite, 5, 1, Const.ColorType.kNone, "0,3"));
            stageData.Add(new StageData(Common.Const.ObjectType.kNormalBlockWhite, 5, 2, Const.ColorType.kWhite));
            stageData.Add(new StageData(Common.Const.ObjectType.kFallBlockWhiteA, 5, 7));
            stageData.Add(new StageData(Common.Const.ObjectType.kLiftBlockWhite, 6, 4, Const.ColorType.kNone, "5,4"));

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
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 9:
        case 10:
            return new StageManagementData(1, 1);
        }
        return null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;

public class StageGenerateManager : MonoBehaviour {

    #region private field
    private MainSceneManager _sceneManager;
    private List<ObjectBase> _stageObjectList;
    private int _stageID;
    #endregion

    #region public function
    /// <summary>
    /// 
    /// </summary>
    public void Init(MainSceneManager sceneManager)
    {
        _sceneManager = sceneManager;
        _stageID      = 1;        
    }

    /// <summary>
    /// ステージID設定
    /// </summary>
    /// <param name="stageID"></param>
    public void SetStageID(int stageID)
    {
        _stageID = stageID;
    }

    /// <summary>
    /// ステージカウントアップ
    /// </summary>
    public void StageCountUp()
    {
        ++_stageID;
    }

    /// <summary>
    /// ステージ作成
    /// </summary>
    public void CreateStage()
    {
        // オブジェクト作成ループ
        var list = StageDataManager.GetStageData(_stageID);
        for(var i = 0; i < list.Count; ++i){

            switch(list[i]._type){
            case Common.Const.ObjectType.kPlayerWhite:
                break;
            }
        }
    }

    /// <summary>
    /// 再度同じステージを作成
    /// </summary>
    public void ReStart(){

    }

    /// <summary>
    /// ステージデータ削除
    /// </summary>
    private void DeleteStageObject()
    {

    }
    #endregion
}

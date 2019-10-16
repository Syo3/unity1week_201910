using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Common;

public class StageGenerateManager : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("ステージの親要素")]
    private GameObject _worldParent;
    [SerializeField, Tooltip("スコープ")]
    private Scope _scope;
    #endregion

    #region private field
    private MainSceneManager _sceneManager;
    private List<ObjectBase> _stageObjectList;
    private int _stageID;
    private List<GoalObject> _goalObjectList;
    private List<Player> _playerObjectList;
    #endregion

    #region access
    public List<GoalObject> GoalObjectList{
        get{return _goalObjectList;}
    }
    public List<Player> PlayerObjectList{
        get{return _playerObjectList;}
    }
    #endregion

    #region public function
    /// <summary>
    /// 
    /// </summary>
    public void Init(MainSceneManager sceneManager)
    {
        _sceneManager    = sceneManager;
        _stageID         = 1;
        _stageObjectList = new List<ObjectBase>();
        _scope.Init(_sceneManager);
        _goalObjectList   = new List<GoalObject>();
        _playerObjectList = new List<Player>();
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
            _stageObjectList.Add(Instantiate(GetStageObjectPrefab(list[i]._type), new Vector3(Common.Const.START_POS_X+Common.Const.BLOCK_SIZE*list[i]._posX, Common.Const.START_POS_Y+Common.Const.BLOCK_SIZE*list[i]._posY, 0.0f), Quaternion.identity, _worldParent.transform).GetComponent<ObjectBase>());
        }
        // オブジェクト初期化ループ
        for(var i = 0; i < _stageObjectList.Count; ++i){

            _stageObjectList[i].Init(_sceneManager);

            if(_stageObjectList[i] is GoalObject){
                _goalObjectList.Add((GoalObject)_stageObjectList[i]);
            }
            if(_stageObjectList[i] is Player){
                _playerObjectList.Add((Player)_stageObjectList[i]);
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
        for(var i = 0; i < _stageObjectList.Count; ++i){
            Destroy(_stageObjectList[i]);
        }
        _stageObjectList  = new List<ObjectBase>();
        _goalObjectList   = new List<GoalObject>();
        _playerObjectList = new List<Player>();
    }

    /// <summary>
    /// オブジェクトのプレハブ取得
    /// </summary>
    /// <param name="objectType"></param>
    /// <returns></returns>
    private GameObject GetStageObjectPrefab(Const.ObjectType objectType)
    {
        switch(objectType){
        case Common.Const.ObjectType.kPlayerWhite:
            return _sceneManager.PrefabManager.WhitePlayerObject;
        case Common.Const.ObjectType.kPlayerBlack:
            return _sceneManager.PrefabManager.BlackPlayerObject;
        case Common.Const.ObjectType.kNormalBlockWhite:
            return _sceneManager.PrefabManager.WhiteNormalBlockObject;
        case Common.Const.ObjectType.kFixedBlock:
            return _sceneManager.PrefabManager.FixedBlockObject;
        case Common.Const.ObjectType.kGoalWhite:
            return _sceneManager.PrefabManager.WhiteGoal;
        }
        return null;
    }
    #endregion
}

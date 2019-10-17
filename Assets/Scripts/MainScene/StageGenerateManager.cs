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
    [SerializeField, Tooltip("終了演出")]
    private Animator _endEffect;
    #endregion

    #region private field
    private MainSceneManager _sceneManager;
    private List<ObjectBase> _stageObjectList;
    private StageManagementData _stageManagementData;
    private int _stageID;
    private List<GoalObject> _goalObjectList;
    private List<Player> _playerObjectList;
    private int _goalActiveCount;
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
        // ステージ管理データ取得
        _stageManagementData = StageDataManager.GetStageManagementData(_stageID);
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
        _goalActiveCount = 0;
        _endEffect.Play("EndEffect_StartEffect");
    }

    /// <summary>
    /// 再度同じステージを作成
    /// </summary>
    public void ReStart()
    {
        DeleteStageObject();
        CreateStage();
    }

    /// <summary>
    /// ゴールカウント追加
    /// </summary>
    public void AddGoalActiveCount()
    {
        ++_goalActiveCount;
        if(_goalActiveCount == _stageManagementData._goalCount){
            SetEndEffect();
            for(var i = 0; i < _playerObjectList.Count; ++i){
                _playerObjectList[i].ActiveFlg = false;
            }
        }
    }

    /// <summary>
    /// ステージ終了演出
    /// </summary>
    public void SetEndEffect()
    {
        _endEffect.Play("EndEffect_Start");
        StartCoroutine(EffectEndCheck());
    }

    /// <summary>
    /// ステージデータ削除
    /// </summary>
    private void DeleteStageObject()
    {
        for(var i = 0; i < _stageObjectList.Count; ++i){
            Destroy(_stageObjectList[i].gameObject);
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

    /// <summary>
    /// ステージ終了演出終了チェック
    /// </summary>
    /// <returns></returns>
    private IEnumerator EffectEndCheck()
    {
        yield return null;
        var stateInfo = _endEffect.GetCurrentAnimatorStateInfo(0);
        while(stateInfo.normalizedTime < 1.0f){
            yield return null;
            stateInfo = _endEffect.GetCurrentAnimatorStateInfo(0);
        }
        // 次のステージ作成
        StageCountUp();
        ReStart();
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("グループ")]
    private CanvasGroup _canvasGroup;
    [SerializeField, Tooltip("リトライボタン")]
    private Button _retryButton;
    #endregion

    #region private field
    private MainSceneManager _sceneManager;
    #endregion

    #region public function
    public void Init(MainSceneManager sceneManager)
    {
        _sceneManager = sceneManager;

        // リトライボタン設定
        _retryButton.onClick.AddListener(()=>{
            _sceneManager.StageGenerateManager.ReStart();
            // ボタンのアニメーションとか入れたいね　狂ってなる
            
        });
    }
    #endregion
}

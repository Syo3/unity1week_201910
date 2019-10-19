using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour {

    #region define
    private float kFlashSpeed = 0.5f;
    #endregion

    #region SerializeField
    [SerializeField, Tooltip("フェード管理")]
    private FadeManager _fadeManager;
    [SerializeField, Tooltip("ロゴアニメーションアニメーター")]
    private Animator _animator;
    [SerializeField, Tooltip("クリックスタート")]
    private SpriteRenderer _clickStartSprite;
    #endregion

    #region private field
    private bool _inifFlg;
    private float _time;
    #endregion

	// Use this for initialization
	void Start ()
    {
        _time    = 4.5f;
        _inifFlg = false;
        _fadeManager.SetCallBack(()=>{
            _animator.Play("TitleLogo_Start");
            StartCoroutine(AnimationEndCheck());
        });
		StartCoroutine(_fadeManager.FadeIn());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!_inifFlg) return;
        Flash();
		KeyCheck();
	}

    /// <summary>
    /// キー入力
    /// </summary>
    private void KeyCheck()
    {
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)){
            MoveMainScene();
        }
    }

    /// <summary>
    /// メインシーンに遷移
    /// </summary>
    private void MoveMainScene()
    {
        _fadeManager.Image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        _fadeManager.SetCallBack(()=>{
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        });
        StartCoroutine(_fadeManager.FadeOut());
    }

    private IEnumerator AnimationEndCheck()
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        while(stateInfo.normalizedTime < 1.0f){
            yield return null;
            stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        }
        yield return new WaitForSeconds(0.6f);
        Debug.Log("init end");
        _inifFlg = true;
    }

    /// <summary>
    /// クリックスタートの点滅
    /// </summary>
    private void Flash()
    {
        _time += Time.deltaTime * 5.0f * kFlashSpeed;
       //α値にSin関数を代入する
        var color = _clickStartSprite.color;
        color.a   = Mathf.Sin(_time) * 0.5f + 0.5f;
        _clickStartSprite.color = color;
    }
}

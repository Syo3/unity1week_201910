using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		KeyCheck();
	}

    /// <summary>
    /// キー入力
    /// </summary>
    private void KeyCheck()
    {
        if(Input.GetMouseButtonUp(0)){
            MoveMainScene();
        }
    }

    /// <summary>
    /// メインシーンに遷移
    /// </summary>
    private void MoveMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}

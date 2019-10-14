using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
   void OnCollisionEnter(Collision collision)
    {
        Debug.Log("当たった!");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("すり抜けた！");
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chamaFases : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D colisao)
	{
		if (colisao.gameObject.tag == "Player") 
		{
			
				SceneManager.LoadScene("fase3");
		}
	}
}

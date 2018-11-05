using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			if (ControleFase.fase == 0) {
				SceneManager.LoadScene ("fase3");
			}else if (ControleFase.fase == 1) {
				SceneManager.LoadScene ("fase5");
			}

		}
		
	}
}

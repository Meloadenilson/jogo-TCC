using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausar : MonoBehaviour {
	private bool pause;
	// Use this for initialization
	void Start () {
		pause = true;
	}
	
	// Update is called once per frame
	 public void Update () {
		//pausar o jogo caso o usuário aperte P ---------------------------------------------------------
		if (Input.GetKeyDown ("p")) {
			if(pause){
				Time.timeScale = 0;
				pause = false;
			}else{
				Time.timeScale = 1;
				pause = true;
			}
		}
		//codigo repetido para poder ser detectado pelo click no botão

	}
	public void pausaTouch(){
		if(pause){
			Time.timeScale = 0;
			pause = false;
		}else{
			Time.timeScale = 1;
			pause = true;
		}
	}
}

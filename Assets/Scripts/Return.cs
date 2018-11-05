using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fase3(){
		SceneManager.LoadScene("fase3");
	}
	public void fase4(){
		SceneManager.LoadScene("fase04");
	}
	public void menu(){
		SceneManager.LoadScene("menu");
	}
	public void controles(){
		SceneManager.LoadScene("controles");
	}
}

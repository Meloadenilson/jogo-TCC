using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class contagemIcones : MonoBehaviour {
	public GameObject f;
	public GameObject r;
	public GameObject i;
	public GameObject o;
	public Text texto;
	string letrasPegas;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		texto.text ="Letras: " + letrasPegas;

	}

	void OnCollisionEnter2D(Collision2D colisao)
	{
		if (colisao.gameObject.tag == "f") {
			
			Destroy (f);
			letrasPegas = letrasPegas + "f";

		} else if (colisao.gameObject.tag == "r") 
		{
			
			Destroy (r);
			letrasPegas = letrasPegas + "r";
		} else if (colisao.gameObject.tag == "i") 
		{
			
			Destroy (i);
			letrasPegas = letrasPegas + "i";
		} else if (colisao.gameObject.tag == "o") 
		{
			
			Destroy (o);
			letrasPegas = letrasPegas + "o";
		}
	}
}

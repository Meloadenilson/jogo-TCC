using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lata : MonoBehaviour {
	public Image imagemlataicone; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D colisao)
	{
		if (colisao.gameObject.tag == "Player") {

			imagemlataicone.enabled = true;
			ChamaFase.iconesPegos++;
				Destroy(gameObject);


		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recupera : MonoBehaviour {
//	public float repoeMana;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			PlayerAtaque.manaAtual += 20;
			Destroy (gameObject);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reciclando : MonoBehaviour {
	public GameObject jogadorAlvo;
	public bool reciclou;
	public GameObject reciclado;
	public Image imagensReciclagem; 
	public float distanciaAlvo;


	// Use this for initialization
	void Start () {
		

		imagensReciclagem.enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		

		if (Vector2.Distance (transform.position, jogadorAlvo.transform.position) < distanciaAlvo) {
			if (ChamaFase.iconesPegos >= 4) {
				imagensReciclagem.enabled = true;
			
				if (Input.GetKeyDown ("r")) {
					ContagemReciclados.reciclados++;
					Destroy (imagensReciclagem);
					reciclou = true;
				} 
			}
		} else if (Vector2.Distance (transform.position, jogadorAlvo.transform.position) > distanciaAlvo) {
			
			imagensReciclagem.enabled = false;

		} 

		if (reciclou)
		{
			Destroy (reciclado);
			ChamaFase.reciclados++;
		}


	}
}

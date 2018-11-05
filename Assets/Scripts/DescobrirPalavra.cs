﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DescobrirPalavra : MonoBehaviour {
	//public static Text palavraDigitada;
	public InputField meuInput;
	public GameObject JogadorFase;
	public float distancia;
	public GameObject quadradoBranco;

	// Use this for initialization
	void Start () {
		meuInput.DeactivateInputField();

	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance (transform.position, JogadorFase.transform.position) < distancia) {
			meuInput.ActivateInputField ();
			Destroy (quadradoBranco);


		} else {
			meuInput.DeactivateInputField();
		}

		if (meuInput.text == "fase") {
			SceneManager.LoadScene ("parabens");
		}
	}
}

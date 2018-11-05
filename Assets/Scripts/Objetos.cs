using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetos : MonoBehaviour {
	public InputField ObjetosInstanciar;
	public GameObject DigitaObjeto;

	public Transform posCaixa;
	public GameObject CaixaPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			DigitaObjeto.gameObject.SetActive (true);
			ObjetosInstanciar.ActivateInputField();
		}

		if (ObjetosInstanciar.text == "caixa") {
			Instantiate (CaixaPrefab, posCaixa.transform.position, posCaixa.transform.localRotation);
			ObjetosInstanciar.text = null;
			DigitaObjeto.gameObject.SetActive (false);
		}
		
	}
}

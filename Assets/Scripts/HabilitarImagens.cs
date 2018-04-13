using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilitarImagens : MonoBehaviour {
	public GameObject jogador;
	public Image imagens; 
	public float distancia;
	// Use this for initialization
	void Start () {
		imagens.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		

		if (Vector2.Distance (transform.position, jogador.transform.position) < distancia) {
			imagens.enabled = true;
		} else if (Vector2.Distance (transform.position, jogador.transform.position) > distancia) {
			imagens.enabled = false;
		} 
	}
}

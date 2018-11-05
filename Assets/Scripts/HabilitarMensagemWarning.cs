using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilitarMensagemWarning : MonoBehaviour {
		public GameObject jogadorw;
		public Image imagensw; 
		public float distanciaw;
		// Use this for initialization
		void Start () {
			imagensw.enabled = false;
		}

		// Update is called once per frame
		void Update () {


			if (Vector2.Distance (transform.position, jogadorw.transform.position) < distanciaw) {
				if (ChamaFase.iconesPegos < 4) 
				{
					imagensw.enabled = true;
				}
			} else if (Vector2.Distance (transform.position, jogadorw.transform.position) > distanciaw) {
				imagensw.enabled = false;
			} 
		}
	}

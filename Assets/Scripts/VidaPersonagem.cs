using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPersonagem : MonoBehaviour {
	float vidaMaxima = 100;

	private Image ImagemVida;
	private float suavizacao;
	public static float vidaAtual;


	// Use this for initialization
	void Start () {
		ImagemVida = GetComponent<Image>();
		vidaAtual = vidaMaxima;
	}
	
	// Update is called once per frame
	void Update () {
		
		suavizacao = Mathf.SmoothStep (ImagemVida.fillAmount, vidaAtual / vidaMaxima, 10 * Time.deltaTime);

		ImagemVida.fillAmount = suavizacao;

		if(Personagem.dano == true){
			vidaAtual -= 10;
			Personagem.dano = false;
		}
	}




}

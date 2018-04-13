using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerAtaque: MonoBehaviour {
	public float tempoMaxCarregar;
	public float delayDoAtaque;
	public float maxMana;
	public static float manaAtual;
	public float custoMagia;
	private float suavizacao;
	public GameObject barraMana; 
	private Image ImagemMana;



	public Transform posicaoDisparo;

	public GameObject magia;
	private float tempoDelay;
	private float tempoCarregar;

	private bool atire ;

	// Use this for initialization
	void Start () {
		tempoCarregar = tempoMaxCarregar;
		manaAtual = maxMana;
		ImagemMana = barraMana.GetComponent<Image>();

	}

	// Update is called once per frame
	void Update ()
	{
		if (manaAtual > maxMana) {
			manaAtual = maxMana;
		} else if (manaAtual < 0) {
			manaAtual = 0;
		}
		if (tempoCarregar <= tempoMaxCarregar)
		{
			tempoCarregar += Time.deltaTime;
		}
		if (Personagem.ataque == true && atire == false)
			{
				
				
				if (tempoCarregar >= tempoMaxCarregar)
				{
					atire = true;
					tempoCarregar = 0;
					manaAtual -= custoMagia;

				}
			}

		if(atire) 
		{
			Disparar ();
		}
		suavizacao = Mathf.SmoothStep (ImagemMana.fillAmount, manaAtual / maxMana, 10 * Time.deltaTime);
		ImagemMana.fillAmount = suavizacao;
	
	}


	public void Disparar()
	{
		tempoDelay += Time.deltaTime;
		if (tempoDelay >= delayDoAtaque && manaAtual > 0) {
			Instantiate (magia, posicaoDisparo.position, posicaoDisparo.rotation);
			tempoDelay = 0;
			atire = false;
			Personagem.ataque = false;

		} else if(manaAtual <=0){
			atire = false;
			Personagem.ataque = false;
		}

	}

}

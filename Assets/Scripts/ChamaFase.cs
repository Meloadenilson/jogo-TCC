using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamaFase : MonoBehaviour {
	public static int iconesPegos =0;
	public static int reciclados;
	public GameObject certoPrefab;
	public Transform pos1;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		

		if (reciclados == 1) {
			Instantiate (certoPrefab, pos1.transform.position, pos1.transform.localRotation);
		}
		if (reciclados == 2) {
			Instantiate (certoPrefab, pos2.transform.position, pos2.transform.localRotation);
		}
		if (reciclados == 3) {
			Instantiate (certoPrefab, pos3.transform.position, pos3.transform.localRotation);
		}
		if (reciclados == 4) {
			Instantiate (certoPrefab, pos4.transform.position, pos4.transform.localRotation);
			reciclados = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D colisao)
	{
		if (colisao.gameObject.tag == "Player") 
		{
			if (iconesPegos >= 4) 
			{
				if (ControleFase.fase == 0) {
					iconesPegos = 0;
					ContagemReciclados.reciclados = 0;
					SceneManager.LoadScene ("fase6");
					ControleFase.fase++;
				} else if (ControleFase.fase == 1) {
					iconesPegos = 0;
					ControleFase.fase = 0;
					SceneManager.LoadScene ("fase5");
				}  
			
			}
		}
	}
		
}

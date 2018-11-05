using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContagemReciclados : MonoBehaviour {
	public static int reciclados; 
	public GameObject Porta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (reciclados == 4)
		{
			reciclados = 5;
			Destroy (Porta);
		}
	}


}

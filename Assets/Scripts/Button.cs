using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public int input = 0;
	public float sensibilidade = 3;
	public bool pressionado;

	public void OnPointerDown(PointerEventData eventData){
		pressionado = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		pressionado = false;
	}

	void Update () {
		if (pressionado) {
			input += 1;
		} else {
			input -= 1;
		}
		input = Mathf.Clamp (input, 0, 1);
	}
}

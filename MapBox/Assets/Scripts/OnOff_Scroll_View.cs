using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff_Scroll_View : MonoBehaviour {

	public bool State_Active_ScrollWiew = false;

	[Range(0,1500f)]
	public float Speed = 1f;
	public float Offset = 15f;

	public GameObject ScrollWiew;
	public GameObject ImegeOn;
	public GameObject ImegeOff;

	private Vector2 Positi_ScrollWiew_on_Start;
	private Vector2 Positi_ScrollWiew_on_Off;


	private bool Click_Button_Funk_On = false;
	private bool Click_Button_Funk_Off = false;



	void Start () {
		Offset = Camera.main.pixelWidth;
		Positi_ScrollWiew_on_Start = ScrollWiew.transform.localPosition;
		ScrollWiew.transform.localPosition = new Vector2 (ScrollWiew.transform.localPosition.x + Offset,ScrollWiew.transform.localPosition.y);
		Positi_ScrollWiew_on_Off = ScrollWiew.transform.localPosition;

		ScrollWiew.SetActive (false);
		ImegeOff.SetActive (false);
	}


	void Update(){
		if (Click_Button_Funk_On) {
			ScrollWiew.transform.localPosition = Vector3.MoveTowards (ScrollWiew.transform.localPosition,Positi_ScrollWiew_on_Start,Speed * Time.deltaTime);
			if (ScrollWiew.transform.localPosition.x <= Positi_ScrollWiew_on_Start.x) {
				Click_Button_Funk_On = false;
				ImegeOff.SetActive (true);
				ImegeOn.SetActive (false);
			}
		}

		if (Click_Button_Funk_Off) {
			ScrollWiew.transform.localPosition = Vector3.MoveTowards (ScrollWiew.transform.localPosition,Positi_ScrollWiew_on_Off,Speed * Time.deltaTime);
			if (ScrollWiew.transform.localPosition.x >= Positi_ScrollWiew_on_Off.x) {
				State_Active_ScrollWiew = false;
				Click_Button_Funk_Off = false;
				ImegeOff.SetActive (false);
				ImegeOn.SetActive (true);
				ScrollWiew.SetActive (false);
			}
		}
	}

	public void Funk_On_Off_ScrollWiew(){
		if(!Click_Button_Funk_On && !Click_Button_Funk_Off){
		if (!State_Active_ScrollWiew) {
			ScrollWiew.SetActive (true);
			State_Active_ScrollWiew = true;
			Click_Button_Funk_On = true;
		} else {
			Click_Button_Funk_Off = true;
		}
		}
	}
}

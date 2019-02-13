using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour {

	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Fire1")){
			rend.material.SetColor("_Color", Random.ColorHSV());
		}
	}
}

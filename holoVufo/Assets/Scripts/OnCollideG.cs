using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideG : MonoBehaviour {

	/*public GameObject go1;
	public GameObject go2;
	public GameObject go3;*/
	public GameObject goG;
	//public GameObject goD;
	public bool g;
	//private bool d;
	private string nameG;
	//private string nameD;

	// Use this for initialization
	void Start () {
		//go3.SetActive(false);
		//int IDlettreG = goG.GetInstanceID();
		//Debug.Log("id : "+goG.GetInstanceID());
		nameG = goG.name;
		Debug.Log("name : "+goG.name);
		/*nameD = goD.name;
		Debug.Log("name : "+goG.name);*/
		//int IDlettreD = lettreD.GetInstanceID();
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if(g && d){
			go3.SetActive(true);
		}
		else{
			go3.SetActive(false);
		}*/
	}

   	private void OnTriggerEnter(Collider other)
    {
    // Change the cube color to green.
    //MeshRenderer meshRend1 = go1.GetComponent<MeshRenderer>();
	 //MeshRenderer meshRend2 = go2.GetComponent<MeshRenderer>();
     //meshRend1.material.color = Color.green;
	 //meshRend2.material.color = Color.green;
	 //go3.GetComponent<MeshRenderer>().enabled = true;
		if(other.name == nameG){
			g = true;
		}
		/*if(other.name == nameD){
			d = true;
		}	*/
	
	 //go3.SetActive(true);
         Debug.Log(other.name);
		 //Debug.Log(other.GetInstanceID());
		 Debug.Log("g " + g);
		 //Debug.Log("d " + d);
  	}

   	private void OnTriggerExit(Collider other)
    {
       	 // Revert the cube color to white.
        //MeshRenderer meshRend1 = go1.GetComponent<MeshRenderer>();
		//MeshRenderer meshRend2 = go2.GetComponent<MeshRenderer>();
        //meshRend1.material.color = Color.white;
		//meshRend2.material.color = Color.white;
		//go3.SetActive(false);
		if(other.name == nameG){
			g = false;
		}
		/*if(other.name == nameD){
			d = false;
		}	*/
		Debug.Log("g " + g);
		//Debug.Log("d " + d);
    }
	
}

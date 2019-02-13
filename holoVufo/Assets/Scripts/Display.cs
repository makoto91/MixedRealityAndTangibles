using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour {
	
	public GameObject go3;
	public GameObject collg;
	public GameObject colld;
	private bool g;
	private bool d;

	// Use this for initialization
	void Start () {
		go3.SetActive(false);
        /*collg = GameObject.Find("BoxCollider1");
		colld = GameObject.Find("BoxCollider3");
        OnCollideG boxColliderG = collg.GetComponent<OnCollideG>();
		OnCollideD boxColliderD = colld.GetComponent<OnCollideD>();
		g = boxColliderG.g;
		d = boxColliderD.d;*/
        //transform.Find("Cube").GetComponent<MeshRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		OnCollideG boxColliderG = collg.GetComponent<OnCollideG>();
		OnCollideD boxColliderD = colld.GetComponent<OnCollideD>();
		g = boxColliderG.g;
		d = boxColliderD.d;
		if(g && d){
			Debug.Log("display : "+(g && d));
			go3.SetActive(true);
            transform.GetComponentInChildren<GameObject>().SetActive(true);
        }
		else{
			go3.SetActive(false);
            transform.GetComponentInChildren<GameObject>().SetActive(false);
        }
	}
}

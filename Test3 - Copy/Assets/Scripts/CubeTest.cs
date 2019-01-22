using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CubeTest : MonoBehaviour, IFocusable, IInputClickHandler {

    public bool Rotating;
    public float RotationSpeed;
    public Vector3 ScaleChange;
    public void OnFocusEnter()
    {
        Rotating = true;
    }

    public void OnFocusExit()
    {
        Rotating = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Rotating)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        }
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        transform.localScale += ScaleChange;
    }

    // Use this for initialization
    void Start () {
		
	}
	
}

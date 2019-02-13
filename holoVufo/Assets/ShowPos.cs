using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPos : MonoBehaviour
{

    public GameObject cube;
    public TextMesh tm;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tm.text = cube.GetComponent<Renderer>().isVisible + " " + cube.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{

    public bool toggleFire;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        toggleFire = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleFire)
        {
            GameObject obj = Instantiate(gameObject, transform.position, Quaternion.LookRotation(Vector3.RotateTowards(gameObject.transform.position, transform.forward, 1.0f, 1.0f)));

            obj.GetComponent<Rigidbody>().velocity = GetComponent<Transform>().forward * 5;
            toggleFire = false;
        }
    }
}

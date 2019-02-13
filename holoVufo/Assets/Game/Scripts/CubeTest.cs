using UnityEngine;

public class CubeTest : MonoBehaviour
{

    public bool Rotating;
    public float RotationSpeed;
    public Vector3 ScaleChange;

    void Update()
    {
        if (Rotating)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        }
    }

    // Use this for initialization
    void Start()
    {
        Rotating = false;
        RotationSpeed = 200;
    }

}

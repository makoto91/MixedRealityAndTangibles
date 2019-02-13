using UnityEngine;
using UnityEngine.Assertions;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float smoothing = 5f;
    Vector3 offset;

    private void Awake()
    {
        Assert.IsNotNull(target);
    }
    // Use this for initialization
    void Start () {
        offset = transform.position - target.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetCamPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime);
	}
}

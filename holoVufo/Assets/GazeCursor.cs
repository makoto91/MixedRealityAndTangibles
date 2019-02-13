using UnityEngine;

public class GazeCursor : MonoBehaviour
{
    GameObject selected;
    [SerializeField]
    public GameObject arrow;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            if (hitInfo.transform.name == "cube" && !selected)
            {
                selected = hitInfo.transform.gameObject;
                selected.GetComponent<CubeTest>().Rotating = true;
                MeshFilter mc = selected.GetComponent<MeshFilter>();
                if (mc != null)
                {
                    Destroy(mc);
                }
            }
            else if ((hitInfo.transform.name.Contains("Tanker") || hitInfo.transform.name.Contains("Solider")))
            {
                selected = hitInfo.transform.gameObject;
                MeshFilter mc = selected.AddComponent<MeshFilter>();
                mc = arrow.GetComponent<MeshFilter>();

                mc.transform.position = selected.transform.position + new Vector3(0.0f, 0.3f, 0.0f);

            }
            else if (selected)
            {
                selected.GetComponent<CubeTest>().Rotating = false;
                
                MeshFilter mc = selected.GetComponent<MeshFilter>();
                if (mc != null)
                {
                    Destroy(mc);
                }
                selected = null;
            }
        } else
        {
            if (selected)
            {
                MeshFilter mc = selected.GetComponent<MeshFilter>();
                if (mc != null)
                {
                    Destroy(mc);
                }
                selected = null;
            }
        }
    }
}
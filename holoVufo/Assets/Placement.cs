using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Placement : MonoBehaviour, ITrackableEventHandler
{
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            var camera = Camera.main;

            var headPosition = camera.transform.position;

            var targetPosition = gameObject.transform.position;

            var positionDelta = targetPosition - headPosition;

            var factoredDelta = 0.5f * positionDelta;

            gameObject.transform.position = targetPosition - factoredDelta;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField]
    Camera camera1;

    [SerializeField]
    Camera camera2;

    [SerializeField]
    GameObject ship;

    void Update()
    {   
        // Checks if the ship is destroyed, and then switches cameras
        if (ship == null)
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
        else if (ship != null)
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }

}

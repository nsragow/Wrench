using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intended to be attached to the camera
/// Controls the scrolling of the camera
/// </summary>
public class CameraScroller : MonoBehaviour
{
    public float initialSpeed;
    Rigidbody2D cameraRigid;
    // Start is called before the first frame update
    void Start()
    {
        cameraRigid = gameObject.AddComponent<Rigidbody2D>();
        cameraRigid.gravityScale = 0;
        cameraRigid.AddForce(new Vector2(0, initialSpeed));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

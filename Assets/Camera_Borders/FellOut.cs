using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellOut : MonoBehaviour
{
    private BorderDetection detector;
    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        detector.ImOutOfView(gameObject);
    }
    /// <summary>
    /// Reserved for BorderDetector;
    /// call when initializing FellOut
    /// </summary>
    /// <param name="detector">the detector to ping on out of view</param>
    public void SetBorderDetector(BorderDetection detector)
    {
        //print("setting detector");
        if(this.detector != null)
        {
            throw new System.Exception("Tried to set the border detector when it was already set");
        }
        this.detector = detector;
    }

    // Start is called before the first frame update
    void Start()
    {
        //print("created!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

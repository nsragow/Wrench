using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDetection : MonoBehaviour
{
    /// <summary>
    /// Any objects placed in here from the editor will be 'Track'ed
    /// </summary>
    public GameObject[] trackThese;

    /// <summary>
    /// Attaches a tracker to the GameObject passed.
    /// will call ImOutOfView when that GameObject is
    /// out of view.
    /// </summary>
    /// <param name="toTrack">untracked GameObject to be tracked</param>
    public void Track(GameObject toTrack)
    {
        FellOut newFellOut = toTrack.AddComponent<FellOut>();
        newFellOut.SetBorderDetector(this);
    }

    /// <summary>
    /// Do not call this - Reserved for tracked Gameobjects
    /// </summary>
    /// <param name="trackedObject">tracked gameobject that fell out of view</param>
    public void ImOutOfView(GameObject trackedObject)
    {
        switch (GetGameType(trackedObject))
        {
            case "wrench":
                WrenchDied(trackedObject);
                break;
            default:
                throw new System.Exception("Not Implemented");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in trackThese)
        {
            this.Track(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private string GetGameType(GameObject toCheck)
    {
        //todo, finish this function
        return "wrench";
    }
    private void WrenchDied(GameObject wrench)
    {
        Debug.LogWarning("Not Implemented WrenchDied in BorderDetection");

    }
}

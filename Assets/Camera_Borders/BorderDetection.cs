using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDetection : MonoBehaviour
{
	public GameState gameState;
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
        //print("start tracking");
        FellOut newFellOut = toTrack.AddComponent<FellOut>();
        newFellOut.SetBorderDetector(this);
    }

    /// <summary>
    /// Do not call this - Reserved for tracked Gameobjects
    /// </summary>
    /// <param name="trackedObject">tracked gameobject that fell out of view</param>
    public void ImOutOfView(GameObject trackedObject)
    {
        Destroy(trackedObject.GetComponent<FellOut>());
        switch (GetGameType(trackedObject))
        {
            
            case "wrench":
                WrenchDied(trackedObject);
                break;
            
            case "tile":
                
                TileOffScreen(trackedObject);
                break;
            
            default:
                throw new System.Exception("Not Implemented");
        }
        
    }

    private void TileOffScreen(GameObject tile)
    {
        //print("border detect");
        tile.GetComponent<Returnable>().Return();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in trackThese)
        {
            this.Track(go);
        }
    }

    


    private string GetGameType(GameObject toCheck)
    {
        if (toCheck.name.Equals("tile"))
        {
            return "tile";
        }
        //todo, finish this function
        return "wrench";
    }
    private void WrenchDied(GameObject wrench)
    {
        //Debug.LogWarning("Not Implemented WrenchDied in BorderDetection");

        //Test for pool recall. Only test. Don't do this at home, please.
        PoolManager pm = FindObjectOfType<PoolManager>();
        pm.RecallBolt(wrench.GetComponent<Bolt>().RecallObject());

    }
}

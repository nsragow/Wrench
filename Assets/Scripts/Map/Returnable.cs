using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Originally intended for returning the gameobject to
/// a resource pool, but do to many unexplained bugs and
/// even freezing of the editor it now only runs the
/// PingMe and Destroy on return.
/// </summary>
public class Returnable : MonoBehaviour
{
    Pingable pingMe;
    private List<GameObject> returnDestination;
    /// <summary>
    /// Currently this function is depricated
    /// </summary>
    /// <param name="returnDestination"></param>
    public void SetReturnTo(List<GameObject> returnDestination)
    {
        this.returnDestination = returnDestination;
    }
    /// <summary>
    /// When the object is no longer necessary,
    /// destroy the game object and ping
    /// </summary>
    public void Return()
    {
        if (pingMe != null)
        {
            //print("pinging!");
            pingMe.Ping(gameObject);
        }
        //print("returning");
        Destroy(gameObject);
        /*
        returnDestination.Add(gameObject);
        //gameObject.SetActive(false);
        
        
        else
        {
            //print("noping");
        }
        */
        
    }
    /// <summary>
    /// Set a pingable to be pinged when
    /// the gameobject is out of use.
    /// For tiles this means falling out of the border
    /// </summary>
    /// <param name="pingMe"></param>
    public void PingMePlease(Pingable pingMe)
    {
        this.pingMe = pingMe;
    }
}

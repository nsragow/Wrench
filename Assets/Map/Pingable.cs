using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Originally part of the grander pool scheme which failed.
/// 
/// Simple class that runs a Callable
/// objects call method when this is pinged
/// </summary>
public class Pingable : MonoBehaviour
{
    Callable onPingAction;
    /// <summary>
    /// Set the Callable object to be the object called
    /// When this is pinged
    /// </summary>
    /// <param name="callable">To be called on ping</param>
    public void OnPing(Callable callable)
    {
        onPingAction = callable;
    }
    /// <summary>
    /// Exposed method: call this to run
    /// the Callables Call method
    /// </summary>
    /// <param name="from"></param>
    public void Ping(GameObject from)
    {
        //print("finally!");

        onPingAction.Call();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class Bolt represents a bolt in the game. Public methods: Reposition, isOccupied
/// 
public class Bolt : MonoBehaviour, IPoolable
{
    
    private bool isOccupied; //Indicates if a wrench is already attached to the bolt
    public Rigidbody2D rb;

    private void Initialize()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    //getters and setters
    public bool IsOccupied { get => isOccupied; set => isOccupied = value; }

    /// <summary>
    /// This method is called by the Wrench when one of its corners collides with the bolt. 
    /// It sets the rotation of the bolt so it matches graphically the rotation of the wrench.
    /// </summary>
    /// <param name="wrenchRotation"></param>
    public void AttachWrench(Quaternion wrenchRotation)
    {
        transform.rotation = wrenchRotation;
        isOccupied = true;
    }

    /// <summary>
    /// Method is called when the time's up and the Bolt must fall.
    /// </summary>
    private void Unscrew()
    {
        //Deactivate the collider to prevent any interaction with other wrenches.
        GetComponent<CircleCollider2D>().enabled = false;
        rb.gravityScale = Constants.bolt_fallingGravity;
        //physics will be simulated now for the fall
        rb.simulated = true;
    }

    /// <summary>
    /// This method is called once the Bolt has fallen so its rotation must be restored, ready to be repositioned.
    /// </summary>
    private void ResetBolt()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero); //is this needed? the angle will be adjusted when wrench attaches anyway
        GetComponent<CircleCollider2D>().enabled = true;
        IsOccupied = false;
        rb.gravityScale = Constants.bolt_startingGravity;
        //stop simulating physics
        rb.simulated = false;
        //Add stuff that needs to be reset HERE
    }

    /// <summary>
    /// Implementation from IPoolable. Hides the object from public view by deactivating it and returns it to be stored in the pool 
    /// </summary>
    public GameObject RecallObject()
    {
        gameObject.SetActive(false);
        return this.gameObject;
    }

    /// <summary>
    /// Method called from the object managing the pool when it's going to be reutilized. This first resets all values to start and 
    /// then assigns the new position. Finally, it activates the gameObject again.
    /// </summary>
    public void Reposition(Vector2 newPosition)
    {
        //Initialize the bolt. Unity seems to not run Start when an interface is implemented as well
        Initialize();
        //reset bolt values
        ResetBolt();
        transform.position = newPosition;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// this method is only for test. Remove for final version. It makes the bolt fall
    /// </summary>
    public void TestUnscrew()
    {
        Unscrew();
    }
}

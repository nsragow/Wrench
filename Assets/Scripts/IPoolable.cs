using UnityEngine;

public interface IPoolable
{
    /// <summary>
    /// This method must deactivate the gameObject so it visually disapears from the scene and stops executing any logic, as well as reset 
    /// any relevant value for its class.
    /// </summary>
    GameObject RecallObject();

    /// <summary>
    /// This method reactivates the gameObject so it's visible again, and also sets its new position in the scene. If needed, reinitialize it according to 
    /// its class.
    /// </summary>
    /// <param name="newPosition"></param>
    void Reposition(Vector2 newPosition);

}

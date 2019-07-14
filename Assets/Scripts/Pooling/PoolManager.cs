using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<GameObject> objectsPool; //Set in Inspector. These can be any type implementing IPoolable
    public GameObject poolable_prefab;

    private Bolt[] activeBolts; //this is only for the Press F test to unscrew all bolts

    /// <summary>
    /// ONLY FOR TESTING, nothing must happen on update
    /// </summary>
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IPoolable tempPoolable = GetIPoolable();

            //Reposition the poolable
            tempPoolable.Reposition(new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            //Make all the active bolts fall. Don't do this at home.
            activeBolts = FindObjectsOfType<Bolt>();
            foreach (Bolt aBolt in activeBolts)
            {
                aBolt.TestUnscrew();
            }
        }
    }

    /// <summary>
    /// This is a temp method. It is called by the borderDectection when a Bolt falls out of the border. This disables the bolt and 
    /// add it again at the end of the pool
    /// </summary>
    /// <param name="fallenBolt"></param>
    public void RecallIPoolable(GameObject fallenBolt)
    {
        objectsPool.Add(fallenBolt);
    }

    /// <summary>
    /// This method returns the first element of the pool, or if the pool is empty, instantiates a new IPoolable element based on the prefab set in inspector (poolable_prefab).
    /// </summary>
    /// <returns></returns>
    public IPoolable GetIPoolable()
    {
        IPoolable tempPoolable = null;

        if (objectsPool.Count > 0)
        {
            //Get the first element from the pool
            tempPoolable = objectsPool[0].GetComponent<IPoolable>();
            //remove the element from the pool
            objectsPool.RemoveAt(0);
        }
        else
        {
            tempPoolable = Instantiate(poolable_prefab).GetComponent<IPoolable>();
        }

        return tempPoolable;
    }
}

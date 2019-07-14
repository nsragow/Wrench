using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Was supposed to deliver tiles from a pool,
/// but now after debugging it only delivers new tiles
/// </summary>
public class TilePoolManager : MonoBehaviour
{
    public GameObject prefab;
    public string identification;
    private List<GameObject> pool;
    
    void Start()
    {
        pool = new List<GameObject>();
    }

    
    /// <summary>
    /// Get a preinitiated tile gameobject
    /// </summary>
    /// <returns></returns>
    public GameObject get()
    {
        
        //if(pool.Count > 1000)
        if(false)
        {
            //print("got from the pool");
            GameObject pref = pool[0];
            pool.RemoveAt(0);
            //pref.SetActive(true);
            return pref;

        }
        
        GameObject newPrefab = Instantiate(prefab);
        Returnable ret = newPrefab.AddComponent<Returnable>();
        newPrefab.AddComponent<Pingable>();
        ret.SetReturnTo(pool);
        newPrefab.name = identification;
        //print("another reprint");
        return newPrefab;
    }
}

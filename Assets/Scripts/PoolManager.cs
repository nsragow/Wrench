using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<GameObject> boltsPool; //Set in Inspector. It can be directly of type Bolt or Tile.
    private Bolt[] activeBolts;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Place a bolt in the scene around 0,0 randomly
            if (boltsPool.Count > 0){
                //Get the first element from the pool
                Bolt tempBolt = boltsPool[0].GetComponent<Bolt>();
                Debug.Log(tempBolt);
                //remove the element from the pool
                boltsPool.RemoveAt(0);
                //Reposition the bolt
                tempBolt.Reposition(new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
            }
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
    public void RecallBolt(GameObject fallenBolt)
    {
        boltsPool.Add(fallenBolt);
    }
}

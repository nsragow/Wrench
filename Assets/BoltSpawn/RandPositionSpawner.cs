using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandPositionSpawner : MonoBehaviour
{
    public static int popCount = 5;

    /// <summary>
    /// Given the tile and a screw prefab,
    /// will spawn popcount prefabs on the correct
    /// random locations of the tile 
    /// </summary>
    /// <param name="tile"></param>
    /// <param name="screwPrefab"></param>
    public void PopulateScaledTile(GameObject tile, GameObject screwPrefab)
    {
        List<Vector3> posLocs = WidthHeightToPos(tile.GetComponent<SpriteRenderer>().bounds.size.x);
        RandSpawn(posLocs, screwPrefab, tile, popCount);
    }

    private void RandSpawn(List<Vector3> possibleLocations, GameObject prefab, GameObject parentObj, int amountSpawned)
    {
        foreach (int index in RandomDistinctRange(possibleLocations.Count, amountSpawned))
        {
            Instantiate(prefab, possibleLocations[index], Quaternion.identity, parentObj.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<int> RandomDistinctRange(int range, int count)
    {
        List<int> randoms = new List<int>();
        int amountAdded = 0;
        while (amountAdded < count)
        {
            int toTry = (int) Random.Range(0, range - 1);
            if (!randoms.Contains(toTry))
            {
                randoms.Add(toTry);
                amountAdded++;
            }
        }
        return randoms;
    }


    private List<Vector3> WidthHeightToPos(float widthHeight)
    {
        List<Vector3> finalPositions = new List<Vector3>();
        foreach(Vector2Int v2 in HardCodedIndicies())
        {
            finalPositions.Add(GetTenByTenGridLoc(v2.x, v2.y, widthHeight));
        }



        return finalPositions;
    }

    private Vector3 GetTenByTenGridLoc(int x, int y, float widthHeight)
    {
        float boxSide = widthHeight / 10;
        float offsetToCenter = boxSide / 2;

        return new Vector3(x * boxSide + offsetToCenter, y * boxSide + offsetToCenter);
    }



    private List<Vector2Int> HardCodedIndicies()
    {
        List<Vector2Int> indicies = new List<Vector2Int>();

        indicies.Add(new Vector2Int(4,0));
        indicies.Add(new Vector2Int(7, 0));

        indicies.Add(new Vector2Int(1, 1));
        indicies.Add(new Vector2Int(2, 1));
        indicies.Add(new Vector2Int(3, 1));
        indicies.Add(new Vector2Int(4, 1));
        indicies.Add(new Vector2Int(5, 1));
        indicies.Add(new Vector2Int(6, 1));
        indicies.Add(new Vector2Int(7, 1));

        indicies.Add(new Vector2Int(0, 2));
        indicies.Add(new Vector2Int(1, 2));
        indicies.Add(new Vector2Int(2, 2));
        indicies.Add(new Vector2Int(4, 2));
        indicies.Add(new Vector2Int(6, 2));
        indicies.Add(new Vector2Int(7, 2));
        indicies.Add(new Vector2Int(8, 2));
        indicies.Add(new Vector2Int(9, 2));

        indicies.Add(new Vector2Int(1, 3));
        indicies.Add(new Vector2Int(2, 3));
        indicies.Add(new Vector2Int(3, 3));
        indicies.Add(new Vector2Int(4, 3));
        indicies.Add(new Vector2Int(5, 3));
        indicies.Add(new Vector2Int(6, 3));
        indicies.Add(new Vector2Int(7, 3));

        indicies.Add(new Vector2Int(0, 4));
        indicies.Add(new Vector2Int(1, 4));
        indicies.Add(new Vector2Int(2, 4));
        indicies.Add(new Vector2Int(3, 4));
        indicies.Add(new Vector2Int(5, 4));
        indicies.Add(new Vector2Int(6, 4));
        indicies.Add(new Vector2Int(7, 4));
        indicies.Add(new Vector2Int(8, 4));
        indicies.Add(new Vector2Int(9, 4));

        indicies.Add(new Vector2Int(2, 5));
        indicies.Add(new Vector2Int(3, 5));
        indicies.Add(new Vector2Int(5, 5));
        indicies.Add(new Vector2Int(6, 5));

        indicies.Add(new Vector2Int(2, 6));
        indicies.Add(new Vector2Int(3, 6));
        indicies.Add(new Vector2Int(4, 6));
        indicies.Add(new Vector2Int(5, 6));
        indicies.Add(new Vector2Int(6, 6));
        indicies.Add(new Vector2Int(7, 6));

        indicies.Add(new Vector2Int(0, 7));
        indicies.Add(new Vector2Int(1, 7));
        indicies.Add(new Vector2Int(2, 7));
        indicies.Add(new Vector2Int(3, 7));
        indicies.Add(new Vector2Int(5, 7));
        indicies.Add(new Vector2Int(6, 7));
        indicies.Add(new Vector2Int(7, 7));
        indicies.Add(new Vector2Int(8, 7));
        indicies.Add(new Vector2Int(9, 7));

        indicies.Add(new Vector2Int(4, 8));
        indicies.Add(new Vector2Int(5, 8));
        indicies.Add(new Vector2Int(6, 8));
        indicies.Add(new Vector2Int(7, 8));

        indicies.Add(new Vector2Int(4, 9));
        indicies.Add(new Vector2Int(7, 9));
        return indicies;
    }

}

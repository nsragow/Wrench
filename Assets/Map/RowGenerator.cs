using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowGenerator : MonoBehaviour, Callable
{
    public BorderDetection borderDetector;

    public int startingRows;
    public int perRow;
    public TilePoolManager poolManager;

    private int deadRows;

    
    private Vector3 nextBottomLeft;

    void Start()
    {
        print("making row gen");
        deadRows = 0;
        gameObject.AddComponent<Pingable>().OnPing(this);

        poolManager = GetComponent<TilePoolManager>();
        Vector3 bottomLeft = GetCameraBottomLeft();

        nextBottomLeft = bottomLeft;

        for(int i = 0; i < startingRows; i++)
        {
            print("Called print next");
            PrintNext();
        }
        
    }

    public void Call()
    {
        print("callllllled");
        deadRows++;
        if(deadRows >= perRow)
        {
            deadRows = 0;
            PrintNext();
        }
    }

    private void PrintNext()
    {
        PrintRowAt(nextBottomLeft);
    }

    private void PrintRowAt(Vector3 bottomLeft)
    {
        float width = 0f;
        float height = 0f;


        float x = 0f;
        float y = 0f;
        float z = 0f;
        for (int i = 0; i < perRow; i++)
        {
            
            GameObject tile = poolManager.get();
            if(tile.GetComponent<SpriteScaler>() == null)
            {
                tile.AddComponent<SpriteScaler>().Scale(perRow);
            }
            width = tile.GetComponent<SpriteRenderer>().bounds.size.x;
            height = tile.GetComponent<SpriteRenderer>().bounds.size.x;

            x = bottomLeft.x + (width * i);
            y = bottomLeft.y;
            z = bottomLeft.z;

            
            tile.transform.position = new Vector3(x,y,0);
            print(tile.transform.position);

            borderDetector.Track(tile);
// tile.SetActive(true);
            tile.GetComponent<Returnable>().PingMePlease(GetComponent<Pingable>());
        }

        x = bottomLeft.x;
        y = bottomLeft.y + (height);
        z = bottomLeft.z;
        nextBottomLeft = new Vector3(x, y, z);
        
    }




    private Vector3 GetCameraBottomLeft()
    {
        float horDist = Camera.main.aspect * Camera.main.orthographicSize;
        float vertDist = Camera.main.orthographicSize;

        float x = Camera.main.transform.position.x;
        float y = Camera.main.transform.position.y;
        float z = Camera.main.transform.position.z;
        
        x -= horDist;
        y -= vertDist;


        Vector3 bl = new Vector3(x, y, z);
        
        return bl;
    }

    
}

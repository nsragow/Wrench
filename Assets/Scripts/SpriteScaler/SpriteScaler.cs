using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    public int countPerScreen;
    public new SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Scale(int perScreen)
    {
        countPerScreen = perScreen;
        renderer = GetComponent<SpriteRenderer>();
        double verticalSize = Camera.main.orthographicSize * 2.0;
        double aspect = Camera.main.aspect;
        
        double horizontalSize = (aspect) * verticalSize;
        
        Vector2 spriteSize = renderer.bounds.size;
        

        float width = spriteSize.x;
        
        float newScale = (float)horizontalSize / (width * countPerScreen);
        
        float x = newScale;
        float y = newScale;
        float z = transform.localScale.z;


        transform.localScale = new Vector3(x, y, z);
    }
    
}

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
        double verticalSize = Camera.main.orthographicSize * 2.0;
        double aspect = Camera.main.aspect;
        print(aspect);
        print("aspect");
        print(Screen.width / Screen.height);
        print("what");
        double horizontalSize = (aspect)*verticalSize;
        print(Screen.width);
        print(Screen.height);
        Vector2 spriteSize = renderer.bounds.size;
        print("hor" +horizontalSize);
        print("ver" + verticalSize);

        float width = spriteSize.x;
        print(width);
        print(renderer.size.x);
        print(transform.localScale.x);

        float newScale =(float) horizontalSize / (width*countPerScreen);
        print(newScale);
        float x = newScale;
        float y = newScale;
        float z = transform.localScale.z;


        transform.localScale = new Vector3(x, y, z);
    }

    
}

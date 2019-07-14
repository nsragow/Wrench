using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneInitializer : MonoBehaviour
{


    public float ratioFromFloor = .2f;

    public void InitPlaying(InitGameSettings settings,GameObject playerPrefab)
    {
        int playerCount = settings.playerControls.Count;

        float screenWidth = (Camera.main.orthographicSize * 2) * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize*2;
        float cameraX = Camera.main.transform.position.x;
        float cameraY = Camera.main.transform.position.y;
        float bottomLeftX = cameraX - (screenWidth / 2);
        float bottomLeftY = cameraY - (screenHeight / 2);

        float xDistBetweenWrenches = screenWidth / (playerCount);
        float sidePadding = xDistBetweenWrenches / 2;
        float bottomPadding = screenHeight * ratioFromFloor;
        print(playerCount);
        int offsetMult = 0;
        foreach(KeyCode controlKey in settings.playerControls)
        {
            //sidePadding = 0;
            float x = (bottomLeftX + sidePadding) + (xDistBetweenWrenches * offsetMult);
            float y = (bottomLeftY + bottomPadding);

            Vector3 startingPos = new Vector3(x, y, 1);

            PlacePlayer(startingPos, controlKey, playerPrefab);

            offsetMult++;
        }
    }
    
    public void PlacePlayer(Vector3 pos, KeyCode controller, GameObject prefab)
    {
        //may run into bug where sorting layer doesnt work
        Instantiate(prefab, pos, Quaternion.identity);
        Debug.LogWarning("trying to place player " + controller + " at loc " + pos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

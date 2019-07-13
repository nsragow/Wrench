using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles UI and creating InitGameSettigns
/// at the KeySelect Scene.
/// </summary>
public class KeySelectHandler : MonoBehaviour
{
    public GameState gameState;
    public KeyCode startGame = KeyCode.Mouse0;
    public KeyCode resetKeys = KeyCode.Mouse1;
    private Dictionary<KeyCode, string> availableKeys;
    private InitGameSettings gameSetting;
    // Start is called before the first frame update
    void Start()
    {
        gameSetting = new InitGameSettings();
        InitAvailableKeys();
    }

    /// <summary>
    /// Checks to see if available keys are pressed, then adds them to selected keys.
    /// also checks if the players are ready to start, or they want to restart selecting keys
    /// </summary>
    void Update()
    {
        foreach(KeyCode key in availableKeys.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                gameSetting.playerControls.Add(key);
                print("added " + key);
            }
        }
        if (Input.GetKeyDown(resetKeys))
        {
            gameSetting.playerControls.Clear();
            print("cleared");
        }
        else if (Input.GetKeyDown(startGame) && gameSetting.playerControls.Count > 0)
        {
            gameState.StartPlaying(gameSetting);
        }
    }


    private void InitAvailableKeys()
    {
        availableKeys = new Dictionary<KeyCode, string>();


        availableKeys.Add(KeyCode.A, "A");
        availableKeys.Add(KeyCode.Space, "Space");
        availableKeys.Add(KeyCode.Return, "Enter");
        availableKeys.Add(KeyCode.CapsLock, "CapsLock");
        availableKeys.Add(KeyCode.RightArrow, "RightArrow");
    }
}

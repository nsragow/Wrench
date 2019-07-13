using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handles UI and creating InitGameSettigns
/// at the KeySelect Scene.
/// </summary>
public class KeySelectHandler : MonoBehaviour
{
    public GameState gameState;
    private KeyCode startGame = KeyCode.Space;
    private KeyCode resetKeys = KeyCode.Escape;
    private InitGameSettings gameSetting;

    [SerializeField] TextMeshProUGUI[] selectionTexts;

    private int currentPlayer;

    void Start()
    {
        currentPlayer = 0;
        gameSetting = new InitGameSettings();
    }

    /// <summary>
    /// Checks to see if available keys are pressed, then adds them to selected keys.
    /// also checks if the players are ready to start, or they want to restart selecting keys
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(resetKeys)) {

            ResetPlayerKeys();
            gameSetting.playerControls.Clear();
            print("Cleared Set Keys");

        } else if (Input.GetKeyDown(startGame) && gameSetting.playerControls.Count > 0) {

            gameState.StartPlaying(gameSetting);

        } else {
            foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
                if (Input.GetKeyDown(key)) {
                    SetKey(key);
                }
            }
        }
    }

    private void SetKey(KeyCode key) {
        gameSetting.playerControls.Add(key);
        selectionTexts[currentPlayer].text = key.ToString();
        currentPlayer++;
    }

    private void ResetPlayerKeys() {
        foreach(TextMeshProUGUI stext in selectionTexts) {
            stext.text = "No Key Selected";
        }
        currentPlayer = 0;
    }
}

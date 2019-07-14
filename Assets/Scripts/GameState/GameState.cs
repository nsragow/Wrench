using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// General GameFlow manager
/// </summary>
public class GameState : MonoBehaviour
{
    [SerializeField]
    private State initialScene;

    public GameObject wrenchPrefab;

    public string splashScreenName;
    public string startScreenName;
    public string playingScreenName;
    public string winScreenName;
    public string keySelectScreenName;
    public string gameOverName;

    [SerializeField] private GameObject optionsPanel;
    private bool optionsActive = false;

    private static int playerCount;
    private static InitGameSettings settings;
    private static State state;

    private static bool isFirstGameState = true;
    /// <summary>
    /// Call when player falls off screen.
    /// Called by BorderDetection.
    /// Can switch scenes.
    /// </summary>
    public void PlayerDied()
    {
        if(state != State.Playing)
        {
            throw new System.Exception("Called PlayerDied when game state was not Playing");
        }
        else if (playerCount <= 0)
        {
            throw new System.Exception("Player Died when there was no players left");
        }
        playerCount--;
        if(playerCount == 1)
        {
            PlayerWon();
        }
        if(playerCount == 0)
        {
            GameOver();
        }
    }

    enum State {Splash, Start, KeySelect, Playing, Win, GameOver}


    private void Awake() {
        if (isFirstGameState) {

            state = initialScene;
            isFirstGameState = false;
            SceneManager.LoadScene(StateToName(initialScene));
        }

        else
        {
            switch(state){
                case State.Playing:
                    PlayerSceneInitializer initializer = gameObject.AddComponent<PlayerSceneInitializer>();
                    initializer.InitPlaying(settings,wrenchPrefab);
                    break;

            }

        }


        

    }

    void Start()
    {

        if (SceneManager.GetActiveScene().name == splashScreenName) {
            state = State.Start;
            StartCoroutine(WaitAndLoadScene(4.5f));
        }

        if (SceneManager.GetActiveScene().name == startScreenName) {
            optionsPanel.SetActive(false);
            optionsActive = false;
        }
    }

    IEnumerator WaitAndLoadScene(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(StateToName(state));
    }


    private string StateToName(State state)
    {
        switch (state)
        {
            case State.Playing:
                return playingScreenName;
            case State.Splash:
                return splashScreenName;
            case State.Start:
                return startScreenName;
            case State.Win:
                return winScreenName;
            case State.KeySelect:
                return keySelectScreenName;
            case State.GameOver:
                return gameOverName;
            default:
                throw new System.Exception("unhandled state " + state);

        }
    }

    private void PlayerWon()
    {
        if (state != State.Playing)
        {
            throw new System.Exception("tried gameover when not playing");
        }
        state = State.Win;
        SceneManager.LoadScene(StateToName(state));
    }
    private void GameOver()
    {
        if(state != State.Playing)
        {
            throw new System.Exception("tried gameover when not playing");
        }
        state = State.GameOver;
        SceneManager.LoadScene(StateToName(state));
    }

    /// <summary>
    /// Given settings, moves game into playing scene.
    /// Requires that current scene is keyselect scene.
    /// </summary>
    /// <param name="settings">Settings to be used for Play scene</param>
    public void StartPlaying(InitGameSettings settings)
    {
        if(state != State.KeySelect)
        {
            throw new System.Exception("tried to start game from wrong position");
        }

        state = State.Playing;
        GameState.settings = settings;
        playerCount = settings.playerControls.Count;
        SceneManager.LoadScene(StateToName(state));

    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OpenOptionsPanel() {
        optionsPanel.SetActive(true);
        optionsActive = true;
    }

    public void CloseOptionsPanel() {
        optionsPanel.SetActive(false);
        optionsActive = false;
    }

    public void OpenKeySelect() {
        state = State.KeySelect;
        SceneManager.LoadScene(StateToName(state));
    }

    private void Update() {


        if (SceneManager.GetActiveScene().name == splashScreenName) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                state = State.Start;
                SceneManager.LoadScene(StateToName(state));
            }
        }

        if (SceneManager.GetActiveScene().name == startScreenName) {
            if (optionsActive && Input.GetKeyDown(KeyCode.Escape)) {
                optionsPanel.SetActive(false);
                optionsActive = false;
            }
        }

    }
}

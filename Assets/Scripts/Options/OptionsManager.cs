using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    #region keys
    const string VOLUME_KEY = "Volume";
    const string DIFFICULTY_KEY = "Difficulty";
    #endregion

    //Constraints
    const float MIN_VOLUME = 0f, MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f, MAX_DIFFICULTY = 1f;


    //Variables
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    #region SettersGetters
    public static void SetVolume(float volume) {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME) {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        } else {
            Debug.LogError("Volume Not Within Range: " + volume);
        }
    }

    public static float GetVolume() {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty) {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else {
            Debug.LogError("Difficulty Not Within Range: " + difficulty);
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
    #endregion

    private void Start() {
        volumeSlider.value = GetVolume();
        difficultySlider.value = GetDifficulty();
    }

    private void Update() {
        //Uncomment when we add music player
        /*        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
                if (mp) {
                    mp.GetComponent<AudioSource>().volume = volumeSlider.value;
                }*/
        SetVolume(volumeSlider.value);
        SetDifficulty(difficultySlider.value);
    }
}

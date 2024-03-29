using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameAudioClip : MonoBehaviour
{
    public bool isBackgroundMusic = false;
    [HideInInspector]
    public float timeAlive = 0;
}

public class AudioManager : MonoBehaviour {

  [SerializeField]
  private AudioClip[] clips;
  private Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

  //This should be an object with an audio source as a component (default settings)
  [SerializeField]
  private GameObject audioPlayer;
  private List<AudioSource> activeAudioPlayers = new List<AudioSource>();

  void Awake()
  {
    foreach (AudioClip clip in clips)
    {
      clipDict.Add(clip.name, clip);
    }
    //set to null so GC will free memory
    clips = null;
  }

  void Update()
  {
    foreach(AudioSource source in activeAudioPlayers)
    {
        Stop(source);
    }
  }

  public void Stop(AudioSource source)
  {
    source.Stop();
    Destroy(source.gameObject);
  }

  public void Play(string clipName, bool isLooping)
  {
    AudioClip clipToPlay = null;
    try
    {
      clipToPlay = clipDict[clipName];
      Play(clipToPlay, isLooping);
    }
    catch (KeyNotFoundException e)
    {
      Debug.LogError("Tried to play audio file that is not in the audio manager!");
    }

  }

  //returns audio source of clip that is playing (you need to keep track of this if you want to premeturely stop the clip!)
  public AudioSource Play(AudioClip clip, bool isLooping)
  {
    GameObject newAudioPlayer = Instantiate(audioPlayer);
    AudioSource source = newAudioPlayer.GetComponent<AudioSource>();
    activeAudioPlayers.Add(source);
    source.loop = isLooping;
    source.clip = clip;
    source.Play();
    return source;
  }
}

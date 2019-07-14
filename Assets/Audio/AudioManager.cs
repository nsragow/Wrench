using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameAudioClip : AudioClip {
  public bool isBackgroundMusic = false;
  [HideInInspector]
  public float timeAlive = 0;
}

public class AudioManager : Monobehaviour {

  [SerializeField]
  private GameAudioClip[] clips;
  private Dictionary<string, GameAudioClip> clipDict = new Dictionary<string, GameAudioClip>();
  
  //This should be an object with an audio source as a component (default settings)
  [SerializeField]
  private GameObject audioPlayer;
  private List<AudioSource> activeAudioPlayers = new List<AudioSource>();
  
  void Awake()
  {
    foreach (GameAudioClip clip in clips)
    {
      clipDict.Add(clip.name, clip);
      if (clip.isBackgroundMusic)
      {
        Play(clip);
      }
    }
    //set to null so GC will free memory
    clips = null;
  }
  
  void Update()
  {
    foreach(AudioSource source in activeAudioPlayers)
    {
      source.clip.timeAlive += Time.deltaTime;
      if (!source.clip.isBackgroudMusic && source.clip.length <= source.clip.timeAlive)
      {
        activeAudioPlayers.Remove(source);
        Stop(source);
      }
    }
  }
  
  public Stop(AudioSource source)
  {
    source.Stop();
    Destroy(source.gameObject);
  }
  
  public GameAudioClip Play(string clipName)
  {
    GameAudioClip clipToPlay = null;
    try
    {
      clipToPlay = clipDict[clipName];
    }
    except (KeyNotFoundException)
    {
      Debug.LogError("Tried to play audio file that is not in the audio manager!");
    }
    Play(clipToPlay);
  }
  
  //returns audio source of clip that is playing (you need to keep track of this if you want to premeturely stop the clip!)
  public AudioSource Play(GameAudioClip clip)
  {
    GameObject newAudioPlayer = Instantiate(audioPlayer);
    source = newAudioPlayer.GetComponent<AudioSource>();
    activeAudioPlayers.Add(source);
    source.loop = true;
    source.clip = clip;
    source.Play();
    return source;
  }

}

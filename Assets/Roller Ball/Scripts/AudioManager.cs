using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName
{
    click,
    obstacleImpact,
    laserHit,
    doorOpen,
    levelClear,
    levelFail,
    starCollect
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip click;
    public AudioClip obstacleImpact;
    public AudioClip laserHit;
    public AudioClip doorOpen;
    public AudioClip levelClear;
    public AudioClip levelFail;
    public AudioClip starCollect;

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;

    private void Awake()
    {
        if (instance == null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void PlaySound(SoundName soundName)
    {
        switch (soundName)
        {
            case SoundName.click:
                soundAudioSource.clip = click;
                break;

            case SoundName.obstacleImpact:
                soundAudioSource.clip = obstacleImpact;
                break;

            case SoundName.laserHit:
                soundAudioSource.clip = laserHit;
                break;

            case SoundName.doorOpen:
                soundAudioSource.clip = doorOpen;
                break;

            case SoundName.levelClear:
                soundAudioSource.clip = levelClear;
                break;

            case SoundName.levelFail:
                soundAudioSource.clip = levelFail;
                break;

            case SoundName.starCollect:
                soundAudioSource.clip = starCollect;
                break;

            default:
                soundAudioSource.clip = obstacleImpact;
                break;
        }

        soundAudioSource.Play();
    }
}

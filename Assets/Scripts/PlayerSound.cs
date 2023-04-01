using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    //Singleton
    public static PlayerSound Instance { get; private set; } = null;

    // Start is called before the first frame update
    public AudioClip jumpFx;
    private AudioSource jumpAudioSource;

    //TODO: create method where audio source is parameter. More sound effects will be added later.

    private void Awake()
    {
        Initializer();

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
       
    }

    private void Initializer()
    {
        jumpAudioSource = gameObject.AddComponent<AudioSource>();

        jumpAudioSource.clip = jumpFx;
        jumpAudioSource.loop = false;
    }

    /// <summary>
    /// Play jump sound fx.
    /// </summary>
    public void PlayJumpSound()
    {
        if (jumpAudioSource == null) return;

        jumpAudioSource.clip = jumpFx;

        if (jumpAudioSource.isPlaying)
            jumpAudioSource.Stop();

        jumpAudioSource.Play();
    }

    /// <summary>
    /// Stop jump sound fx.
    /// </summary>
    public void StopJumpSound()
    {
        if(jumpFx == null) return;

        if (jumpAudioSource.isPlaying)
            jumpAudioSource.Stop();
    }

    /// <summary>
    /// Returns true if jump sound fx is playing
    /// </summary>
    /// <returns></returns>
    public bool IsJumpSoundPlaying()
    {
        return jumpFx != null && jumpAudioSource.isPlaying;
    }

}

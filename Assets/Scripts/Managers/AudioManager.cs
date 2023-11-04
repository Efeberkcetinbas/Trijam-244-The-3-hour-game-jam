using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip GameLoop,BuffMusic;
    public AudioClip GameOverSound,CollectKeySound,PlayerGetDamageSound;

    AudioSource musicSource,effectSource;

    private bool hit;

    private void Start() 
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = GameLoop;
        //musicSource.Play();
        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.volume=0.4f;
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.AddHandler(GameEvent.OnCollectKey,OnCollectKey);
        EventManager.AddHandler(GameEvent.OnPlayerGetDamage,OnPlayerGetDamage);
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.RemoveHandler(GameEvent.OnCollectKey,OnCollectKey);
        EventManager.RemoveHandler(GameEvent.OnPlayerGetDamage,OnPlayerGetDamage);
    }

    

    void OnGameOver()
    {
        effectSource.PlayOneShot(GameOverSound);
    }

    private void OnCollectKey()
    {
        effectSource.PlayOneShot(CollectKeySound);
    }

    private void OnPlayerGetDamage()
    {
        effectSource.PlayOneShot(PlayerGetDamageSound);
    }

}

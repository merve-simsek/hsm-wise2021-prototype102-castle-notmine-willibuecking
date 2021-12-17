using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameOver;
    public AudioClip[] clips;
    private AudioSource _soundPlayer;
    void Awake()
    {
        _soundPlayer = GetComponent<AudioSource>();
    }

    public void RockBreaking()  //plays a random sound if a rock breaks
    {
        if (!_soundPlayer.isPlaying)
        {
            int randomClip = Random.Range(0, clips.Length);
            _soundPlayer.clip = clips[randomClip];
            _soundPlayer.Play();
        }
    }

    public void GameOverSound()
    {
        _soundPlayer.clip = gameOver;
        _soundPlayer.Play();
    }
}

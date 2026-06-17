using System;
using UnityEngine;
using VContainer;
public class GameSceneSound:MonoBehaviour,ISceneSound
{
    [SerializeField] private AudioClip mainTheme;
    [SerializeField] private AudioClip playWinRoundSound;
    [SerializeField] private AudioClip playLooseRoundSound;
    [SerializeField] private AudioClip playWinGameSound;
    [SerializeField] private AudioClip playLooseGameSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioSource sourceMusic;
    [SerializeField] private AudioSource sourceGame;
    void Start()
    {
        sourceMusic.clip=mainTheme;
        sourceMusic.loop=true;
    }
    public void StartSceneTheme()
    {
        sourceMusic.Play();
    }
    public void EndSceneTheme()
    {
        
    }
    public void PlayWinRoundSound()
    {
        sourceGame.PlayOneShot(playWinRoundSound);
    }
    public void PlayWinGameSound()
    {
        sourceGame.PlayOneShot(playWinGameSound);
    }
    public void PlayLooseRoundSound()
    {
        sourceGame.PlayOneShot(playLooseRoundSound);
    }
    public void PlayLooseGameSound()
    {
        sourceGame.PlayOneShot(playLooseGameSound);
    }
    public void PlayClickSound()
    {
        sourceGame.PlayOneShot(clickSound);
    }
}
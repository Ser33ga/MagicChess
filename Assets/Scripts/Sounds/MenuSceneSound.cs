using System;
using UnityEngine;
using VContainer;
public class MenuSceneSound: MonoBehaviour,ISceneSound
{
    [SerializeField] private AudioClip mainTheme;
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
    public void PlayClickSound()
    {
        sourceGame.PlayOneShot(clickSound);
    }
}
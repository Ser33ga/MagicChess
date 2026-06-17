using UnityEngine;
using UnityEngine.Audio;
using VContainer;
public class SettingsController
{
    [Inject] AudioMixer mixer;
    [Inject] AudioListener mainListener;
    public GameSettings currentSettings=new GameSettings{};
    public GameSettings LoadSettings()
    {
        return currentSettings;
    }
    public void SaveSettings(GameSettings settings)
    {
        currentSettings=settings;
    }
    public void ApplySettings(GameSettings settings)
    {
        mixer.SetFloat("Master",
            settings.soundStrenght <= 0.0001f ? -80f : Mathf.Log10(settings.soundStrenght) * 20f);
        mixer.SetFloat("Game",
            settings.soundStrenghtGame <= 0.0001f ? -80f : Mathf.Log10(settings.soundStrenghtGame) * 20f);
        mixer.SetFloat("Music",
            settings.soundStrenghtMusic <= 0.0001f ? -80f : Mathf.Log10(settings.soundStrenghtMusic) * 20f);
    }
}
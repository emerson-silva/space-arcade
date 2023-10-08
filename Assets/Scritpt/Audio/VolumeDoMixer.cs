using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeDoMixer : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private string volumeEfeitos;
    [SerializeField] 
    private string volumeMusica;

    void Start()
    {
        if (PlayerPrefs.HasKey(this.volumeEfeitos)) {
            this.DefinirVolume(this.volumeEfeitos, PlayerPrefs.GetFloat(this.volumeEfeitos));
        }
        if (PlayerPrefs.HasKey(this.volumeMusica))
        {
            this.DefinirVolume(this.volumeMusica, PlayerPrefs.GetFloat(this.volumeMusica));
        }
    }

    public void UpdateMusicVolume(float value)
    {
        this.DefinirVolume(this.volumeMusica, value);
        this.SalvarVolume(this.volumeMusica, value);
    }

    public void UpdateEffectVolume(float value)
    {
        this.DefinirVolume(this.volumeEfeitos, value);
        this.SalvarVolume(this.volumeEfeitos, value);
    }

    private void DefinirVolume(string exposedParam, float value)
    {
        value = Mathf.Log10(value) * 20;
        this.mixer.SetFloat(exposedParam, value);
    }

    private void SalvarVolume(string param, float value)
    {
        PlayerPrefs.SetFloat(param, value);
    }
}

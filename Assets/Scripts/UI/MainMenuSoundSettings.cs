using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class MainMenuSoundSettings : MonoBehaviour
{
    [Serializable]
    public struct AudioSliderPair
    {
        public string name;
        public string parameterName;
        public Slider slider;
        public AudioSource audioSource;
    }

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSliderPair[] audioSettings;
    
    private void Start()
    {
        this.Setup();
    }

    private void Setup()
    {
        foreach (AudioSliderPair pair in this.audioSettings)
        {
            if (!PlayerPrefs.HasKey(this.GetPrefKey(pair.name)))
            {
                PlayerPrefs.SetFloat(this.GetPrefKey(pair.name), pair.slider.maxValue);
            }
            
            float currentValue = PlayerPrefs.GetFloat(this.GetPrefKey(pair.name));
            pair.slider.value = currentValue;
            this.mixer.SetFloat(pair.parameterName, currentValue);
            
            pair.slider.onValueChanged.AddListener(CreateValueListener(pair));
        }

        PlayerPrefs.Save();
    }

    private UnityAction<float> CreateValueListener(AudioSliderPair pair)
    {
        return (value) =>
        {
            PlayerPrefs.SetFloat(this.GetPrefKey(pair.name), value);
            PlayerPrefs.Save();
            
            this.mixer.SetFloat(pair.parameterName, value);
            pair.audioSource.Play();
        };
    }
    
    private string GetPrefKey(string name) => $"audio_{name}";
}
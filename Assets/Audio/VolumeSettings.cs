using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider voiceSlider;
    [SerializeField] Slider musicSlider;

    const string SFX_VOLUME = "SfxVolume";
    const string VOICE_VOLUME = "VoiceVolume";
    const string MUSIC_VOLUME = "MusicVolume";

    private void Awake()
    {
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        voiceSlider.onValueChanged.AddListener(SetVoiceVolume);
        musicSlider.onValueChanged.AddListener(setMusicVolume);
    }

    private void Start()
    {
        float sfxVolume = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, AudioManager.DEFAULT_SFX_VOLUME);
        sfxSlider.value = sfxVolume;

        float voiceVolume = PlayerPrefs.GetFloat(AudioManager.VOICE_KEY, AudioManager.DEFAULT_VOICE_VOLUME);
        voiceSlider.value = voiceVolume;

        float musicVolume = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, AudioManager.DEFAULT_MUSIC_VOLUME);
        musicSlider.value = musicVolume;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
        PlayerPrefs.SetFloat(AudioManager.VOICE_KEY, voiceSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
    }

    public void SetSfxVolume(float volume)
    {
        audioMixer.SetFloat(SFX_VOLUME, Mathf.Log10(volume) * 20);
    }

    public void SetVoiceVolume(float volume)
    {
        audioMixer.SetFloat(VOICE_VOLUME, Mathf.Log10(volume) * 20);
    }

    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(volume) * 20);
    }
}

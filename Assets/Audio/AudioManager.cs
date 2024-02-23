using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer audioMixer;
    public const float DEFAULT_SFX_VOLUME = 0.75f;
    public const float DEFAULT_VOICE_VOLUME = 0.75f;
    public const float DEFAULT_MUSIC_VOLUME = 0.75f;

    public const string SFX_KEY = "SfxVolume";
    public const string VOICE_KEY = "VoiceVolume";
    public const string MUSIC_KEY = "MusicVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);    
        }
    }

    private void Start()
    {
        LoadVolume();
    }

    private void LoadVolume()
    {
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, DEFAULT_SFX_VOLUME);
        audioMixer.SetFloat(SFX_KEY, Mathf.Log10(sfxVolume) * 20);

        float voiceVolume = PlayerPrefs.GetFloat(VOICE_KEY, DEFAULT_VOICE_VOLUME);
        audioMixer.SetFloat(VOICE_KEY, Mathf.Log10(voiceVolume) * 20);

        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, DEFAULT_MUSIC_VOLUME);
        audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(musicVolume) * 20);
    }
}

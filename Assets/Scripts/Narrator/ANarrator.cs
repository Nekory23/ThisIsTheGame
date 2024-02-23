using UnityEngine;

public abstract class ANarrator : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        Debug.Assert(audioSource != null, "Narrator needs an AudioSource component");
    }

    public void RunAudioClip(string clipName)
    {
        audioSource.Stop();
        var clip = Resources.Load<AudioClip>(clipName);
        audioSource.clip = clip;
        audioSource.Play();
    }

    public abstract void OnNotify(PlayerAction action);
}

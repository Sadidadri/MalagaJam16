using UnityEngine;

public class AudioLevel1 : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            // Move to the next audio clip in the array (loop back to the beginning if the end is reached)
            currentClipIndex = 1;
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
        }
    }
}
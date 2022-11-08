using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;

    public void FadeAudio()
    {
        // Currently I do not know how to fade out audio.
        // from what I could find, it seems I need to use co-routines.
        // This is out of scope for my purposes this time and may be investigated later
        audioSource.Stop(); // This call will immediately stop the audio source playing
    }
}
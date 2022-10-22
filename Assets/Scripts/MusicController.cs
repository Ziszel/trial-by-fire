using UnityEngine;

public class MusicController : MonoBehaviour
{
    public MusicController Instance;
    public AudioSource audio;

    // Something to do with making this static, makes it impossible to use audio.Play(), whether explicit call in the Awake method
    // or via the editor
    /*private void Awake()
    {
        // on death, the music must not restart, therefore create it as a static object
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }*/

    public void FadeAudio()
    {
        // Currently I do not know how to fade out audio.
        // from what I could find, it seems I need to use co-routines.
        // This is out of scope for my purposes this time and will be investigated later
        audio.Stop();
    }
}
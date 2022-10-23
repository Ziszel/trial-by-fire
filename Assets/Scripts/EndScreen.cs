using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Text timer;
    public Text deathCount;
    public Text endMessage;
    public Text btnText;
    public Transform sceneCamera;
    public Button btn;
    public AudioSource music;
    public AudioSource doorSlam;
    private int playCount = 0;

    private void Awake()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameManager.bestTime);
        
        deathCount.text = "Deaths: " + GameManager.deathCount;
        timer.text = "BestTime: " + timeSpan.ToString("hh':'mm':'ss", new CultureInfo("en-GB"));
        btn.onClick.AddListener(OnPlayAgainClick);
    }

    private void Update()
    {
        if (sceneCamera.position.z > 2 && playCount < 1)
        {
            doorSlam.Play();
            playCount++;
        }
        // If the camera has finished moving past the door, then draw the EndScreen
        if (sceneCamera.position.z > 2 && !doorSlam.isPlaying)
        {
            endMessage.enabled = true;
            timer.enabled = true;
            deathCount.enabled = true;
            btn.enabled = true;
            btn.image.enabled = true;
            btnText.enabled = true;
            if (!music.isPlaying)
            {
                music.Play();
            }
        }
    }

    void OnPlayAgainClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

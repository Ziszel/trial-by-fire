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
    private int _playCount = 0;

    private void Awake()
    {
        // Get a timeSpan object based off of the GameManager variable BestTime.
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameManager.BestTime);
        // Update deathCount and timer buttons with the relevant information from the last playthrough.
        deathCount.text = (MainMenuManager.Language == "English")
            ? "Deaths: " + GameManager.DeathCount
            : "死亡人数: " + GameManager.DeathCount;
        timer.text = (MainMenuManager.Language == "English")
            ? "BestTime: " + timeSpan.ToString("hh':'mm':'ss", new CultureInfo("en-GB"))
            : "时间: " + timeSpan.ToString("hh':'mm':'ss", new CultureInfo("en-GB"));
            btn.onClick.AddListener(OnPlayAgainClick); // add a new listener for the button.
        UpdateEndMessageLanguage(); // Update the large end message string so that it is in the correct language.
    }

    private void Update()
    {
        // If the camera has not yet passed the door, and we haven't played a door slam, play a doorslam sound
        if (sceneCamera.position.z > 2 && _playCount < 1)
        {
            doorSlam.Play();
            _playCount++; // update playCount by 1. This will ensure this if statement is not actioned again.
        }
        // If the camera has finished moving past the door, and we've played the doorSlam, then draw the EndScreen.
        if (sceneCamera.position.z > 2 && !doorSlam.isPlaying)
        {
            endMessage.enabled = true;
            timer.enabled = true;
            deathCount.enabled = true;
            btn.enabled = true;
            btn.image.enabled = true;
            btnText.enabled = true;
            if (!music.isPlaying) // If we're not playing music, play music.
            {
                music.Play();
            }
        }
    }

    private void UpdateEndMessageLanguage()
    {
        // depending on if the selected Language is in English or Chinese, update the endMessage and button text
        if (MainMenuManager.Language == "English")
        {
            endMessage.text = @"Congratulations, you escaped your Trial by Fire!
            
            However; for setting that factory ablaze, you will have to contend with a Trial by Law!";
            btnText.text = "Play again?";
        }
        else
        {
            endMessage.text = @"恭喜，你逃脱了火之试炼!
            
            然而; 放火烧那家工厂，你将不得不接受法律审判";
            btnText.text = "再玩一遍?";
        }
    }

    private void OnPlayAgainClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

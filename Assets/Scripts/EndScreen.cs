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
        deathCount.text = (MainMenuManager.language == "English")
            ? "Deaths: " + GameManager.deathCount
            : "死亡人数: " + GameManager.deathCount;
        timer.text = (MainMenuManager.language == "English")
            ? "BestTime: " + timeSpan.ToString("hh':'mm':'ss", new CultureInfo("en-GB"))
            : "时间: " + timeSpan.ToString("hh':'mm':'ss", new CultureInfo("en-GB"));
            btn.onClick.AddListener(OnPlayAgainClick);
        UpdateEndMessageLanguage();
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

    void UpdateEndMessageLanguage()
    {
        if (MainMenuManager.language == "English")
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

    void OnPlayAgainClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

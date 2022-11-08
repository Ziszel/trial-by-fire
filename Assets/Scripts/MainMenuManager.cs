using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playBtn;
    public Text playBtnText;
    public Button languageBtn;
    public Text languageBtnText;
    public EventSystem eventSystem;
    public static string Language;

    // Awake is called either when an active GameObject that contains the script is initialized when a Scene loads,
    // or when a previously inactive GameObject is set to active, or after a GameObject created with
    // Object.Instantiate is initialized. Use Awake to initialize variables or states before the application starts.
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    private void Awake()
    {
        playBtn.onClick.AddListener(OnPlayClick);
        languageBtn.onClick.AddListener(OnLanguageClick);
        Language = "English";
    }

    private void OnPlayClick()
    {
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            FindObjectOfType<GameManager>().Reset();
        }
    }
    
    private void OnLanguageClick()
    {
        if (Language.Equals("English"))
        {
            Language = "中文";
            playBtnText.text = "玩";
        }
        else if (Language.Equals("中文"))
        {
            Language = "English";
            playBtnText.text = "Play";
        }
        languageBtnText.text = Language;
        // https://answers.unity.com/questions/883220/how-to-change-selected-button-in-eventsystem-or-de.html
        // The 'selected' property of a button cannot be manipulated through the button itself.
        // Because I'm calling this when the language button is clicked, it will always deselect the right thing.
        // What this looks like in-game is that the button bg colour will fade out instantly after clicking
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}


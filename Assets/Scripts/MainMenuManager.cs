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
    public Text titleText;
    public EventSystem eventSystem;
    private static string language;
    //private Color currentColour = new Color(192, 77, 34, 0);

    private void Awake()
    {
        playBtn.onClick.AddListener(OnPlayClick);
        languageBtn.onClick.AddListener(OnLanguageClick);
        language = "English";
        //playBtn.enabled = false;
        //playBtnText.enabled = false;
        //languageBtn.enabled = false;
        //languageBtnText.enabled = false;
        //titleText.color = currentColour;
    }

    private void Update()
    {
        // I think this should work, the values are correct but Unity forces the text to be white. For now, no fade in!
        /*if (titleText.color.a != 255)
        {
            // A lerp stands for linear interpolation. Lerp is where we go from one value, to another, linearly as defined by a scale of time.
            // It is often used in graphics, here I am using it to change from the colour of the menu text from having 0 alpha (invisible)
            // to full alpha, therefore creating a fade in.
            currentColour.a += Time.deltaTime;
            titleText.color = currentColour;
        }
        else
        {
            ActivateButtons();
        }*/
        
        //ActivateButtons();

        languageBtnText.text = language;
    }

    void ActivateButtons()
    {
        if (!playBtn.enabled)
        {
            playBtn.enabled = true;
            playBtnText.enabled = true;
            languageBtn.enabled = true;
            languageBtnText.enabled = true;
        }
    }

    string GetLanguage()
    {
        return language;
    }

    void OnPlayClick()
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
    
    void OnLanguageClick()
    {
        if (language.Equals("English"))
        {
            language = "Mandarin";
        }
        else if (language.Equals("Mandarin"))
        {
            language = "English";
        }
        
        // https://answers.unity.com/questions/883220/how-to-change-selected-button-in-eventsystem-or-de.html
        // The 'selected' property of a button cannot be manipulated through the button itself.
        // Because I'm calling this when the language button is clicked, it will always deselect the right thing.
        // What this looks like in-game is that the button bg colour will fade out instantly after clicking
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Components
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject OptionsScreen;
    [SerializeField] private GameObject QuitPrompt;

    //Variables
    private bool PauseCanOpen = true; //To stop multiple menus from being open at the same time

    //Buttons. Too many buttons.

    //Pausing
    public void OnPause()
    {
        if (PauseCanOpen)
        {
            PauseScreen.SetActive(true);
        }
    }

    public void OnUnpause()
    {
        PauseScreen.SetActive(false);
    }

    //Options
    public void OnOpenOptions()
    {
        PauseCanOpen = false;
        PauseScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }

    public void OnCloseOptions()
    {
        PauseCanOpen = true;
        OptionsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    //Quit Prompt
    public void OnQuitTry()
    {
        PauseCanOpen = false;
        PauseScreen.SetActive(false);
        QuitPrompt.SetActive(true);
    }

    public void OnQuitUntry()
    {
        PauseCanOpen = true;
        QuitPrompt.SetActive(false);
        PauseScreen.SetActive(true);
    }

    //Actually Quitting
    public void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

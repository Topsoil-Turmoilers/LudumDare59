using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Components
    [SerializeField] private GameObject OptionsCanvas;
    [SerializeField] private GameObject CreditsCanvas;

    //Variables
    [SerializeField] private GameObject dial;
    [SerializeField] private GameObject startLight;
    [SerializeField] private GameObject optionsLight;
    [SerializeField] private GameObject creditsLight;
    [SerializeField] private GameObject exitLight;

    //Button Functionality
    public void OnButtonStart()
    {
        //Switch Scene to Level 1?
        //Ideally would switch to a cutscene then level 1's start, etc
        SceneManager.LoadScene("Level");
    }

    public void OnButtonOptions()
    {
        //Opens Options
        OptionsCanvas.gameObject.SetActive(!OptionsCanvas.activeInHierarchy);

        //Makes sure Credits is closed
        CreditsCanvas.gameObject.SetActive(false);
    }

    public void OnButtonCredits()
    {
        //Opens Credits
        CreditsCanvas.gameObject.SetActive(!CreditsCanvas.activeInHierarchy);

        //Makes sure Options is closed
        OptionsCanvas.gameObject.SetActive(false);
    }

    public void OnButtonExit()
    {
        #if UNITY_EDITOR
            //This will only be in the Unity Editor. Not in the build.
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    //Button Aesthetics
    public void ButtonHoverStart()
    {
        dial.transform.rotation = Quaternion.Euler(0, 0, 45);
        startLight.GetComponent<Image>().color = Color.green;
    }

    public void ButtonHoverOptions()
    {
        dial.transform.rotation = Quaternion.Euler(0, 0, 20);
        optionsLight.GetComponent<Image>().color = Color.green;
    }

    public void ButtonHoverCredits()
    {
        dial.transform.rotation = Quaternion.Euler(0, 0, -20);
        creditsLight.GetComponent<Image>().color = Color.green;
    }

    public void ButtonHoverExit()
    {
        dial.transform.rotation = Quaternion.Euler(0, 0, -45);
        exitLight.GetComponent<Image>().color = Color.green;
    }
    public void ButtonHoverNoMore()
    {
        dial.transform.rotation = Quaternion.Euler(0, 0, 0);
        startLight.GetComponent<Image>().color = Color.white;
        optionsLight.GetComponent<Image>().color = Color.white;
        creditsLight.GetComponent<Image>().color = Color.white;
        exitLight.GetComponent<Image>().color = Color.white;
    }
}

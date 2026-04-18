using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject OptionsCanvas;
    [SerializeField] private GameObject CreditsCanvas;

    public void OnButtonStart()
    {
        //Switch Scene to Level 1?
        //Ideally would switch to a cutscene then level 1's start, etc
        SceneManager.LoadScene("Level");
    }

    public void OnButtonOptions()
    {
        OptionsCanvas.gameObject.SetActive(!OptionsCanvas.activeInHierarchy);
    }

    public void OnButtonCredits()
    {
        CreditsCanvas.gameObject.SetActive(!CreditsCanvas.activeInHierarchy);
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
}

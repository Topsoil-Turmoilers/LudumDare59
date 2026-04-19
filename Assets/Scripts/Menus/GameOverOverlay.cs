using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOverlay : MonoBehaviour
{
    public static GameOverOverlay Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] private GameObject GOScreen;

    //Use this when a Game Over is triggered
    public void OnGameOver()
    {
        GOScreen.SetActive(true);
    }

    public void TryAgain()
    {
        //put reset level code here? but like to where they just were idk
        GOScreen.SetActive(false);
        //hard-resets the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void ToMainMenu()
    {
        //To Menu :)
        SceneManager.LoadScene("MainMenu");
    }
}

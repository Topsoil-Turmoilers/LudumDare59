using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOverlay : MonoBehaviour
{
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
    }

    public void ToMainMenu()
    {
        //To Menu :)
        SceneManager.LoadScene("MainMenu");
    }
}

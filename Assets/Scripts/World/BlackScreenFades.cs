using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackScreenFades : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private float alphaColor;

    [SerializeField] private GameObject EndCanvas;

    private void Awake()
    {
        alphaColor = blackScreen.GetComponent<Image>().color.a;
    }

    public void FadeOut()
    {
        if (alphaColor >= 0)
        {
            alphaColor -= Time.deltaTime / 2;
            blackScreen.GetComponent<Image>().color = new Vector4(0, 0, 0, alphaColor);
        }
        else
        {
            blackScreen.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
        }
    }

    public void FadeIn()
    {
        if (alphaColor <= 1)
        {
            alphaColor += Time.deltaTime / 2;
            blackScreen.GetComponent<Image>().color = new Vector4(0, 0, 0, alphaColor);
        }
        else
        {
            blackScreen.GetComponent<Image>().color = new Vector4(0, 0, 0, 1);
            EndCanvas.SetActive(true);
            StartCoroutine(WaitThenMenu());
        }
    }

    public IEnumerator WaitThenMenu()
    {
        yield return new WaitForSeconds(5);
        BackToMenu();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

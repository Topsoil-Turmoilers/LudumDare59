using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    [SerializeField] private DialogueObject prologueDialog;
    [SerializeField] private GameObject prologueTextCanvas;

    private void Start()
    {
        DialogueManager.instance.StartDialogue(prologueDialog);

        StartCoroutine(showNOW());

        DialogueManager.onDialogueFinished += DialogueManager_onDialogueFinished;
    }

    private void DialogueManager_onDialogueFinished()
    {
        Debug.Log("PROLOGUE DONE");
        DialogueManager.onDialogueFinished -= DialogueManager_onDialogueFinished;
        SceneManager.LoadScene("Level");
    }

    private IEnumerator showNOW()
    {
        yield return new WaitForSeconds(1);
        //Just in Case
        prologueTextCanvas.SetActive(true);
    }
}

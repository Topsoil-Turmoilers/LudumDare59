using UnityEngine;
using UnityEngine.AI;

public class RadioDialogue : MonoBehaviour
{
    [SerializeField] private RadioData[] RequiredRadioData;
    [SerializeField] private bool[] hasConnected;
    [SerializeField] private InteractionHook[] InteractionHooks;

    [SerializeField] private DialogueObject channelNotOpen;
    [SerializeField] private DialogueObject missingToggle;

    private void Awake()
    {
        //hasConnected = new bool[RequiredRadioData.Length];
        //for (int i = 0; i < hasConnected.Length; i++)
        //{
        //    hasConnected[i] = false;
        //}
    }
    public void MakeCallBack(int callIndex)
    {
        if (hasConnected[callIndex])
        {
            InteractionHooks[callIndex].OnInteract();
        }
        else
        {
            DialogueManager.instance?.StartDialogue(channelNotOpen);
        }
    }
    public float MakeCall(RadioData incomingSettings)
    {
        float similarity = 0f;
        for (int i = 0; i < RequiredRadioData.Length; i++)
        {
            similarity = Mathf.Max(similarity, Similarity(incomingSettings, RequiredRadioData[i]));
            if (similarity >= 2f){
                Debug.Log("Match Found!");
                hasConnected[i] = true;
                InteractionHooks[i].OnInteract();
                return similarity;
            }
        }
        return similarity;
    }

    private float Similarity(RadioData input, RadioData comparison)
    {
        float similarity = 3;



        //this code currently assumes values between 0 and 1 for each slider
        //if(Mathf.Abs(input.horizontalPosition - comparison.horizontalPosition) <= 0.35f)
        //{
        //    similarity += 1;
        //}

        //for every 0.35 'map units' (scale 0-5) away, lose 1 point of similarity 
        similarity -= (Mathf.Abs(input.horizontalPosition - comparison.horizontalPosition)) / 0.35f;

        //this code currently assumes values between 0 and 1 for each slider
        //if (Mathf.Abs(input.verticalPosition - comparison.verticalPosition) <= 0.35f)
        //{
        //    similarity += 1;
        //}

        //for every 0.35 'map units' (scale 0-5) away, lose 1 point of similarity 
        similarity -= (Mathf.Abs(input.verticalPosition - comparison.verticalPosition)) / 0.35f;

        //this code currently assumes values between 0 and 1 for each slider
        if (Mathf.Abs(input.frequency - comparison.frequency) <= 25f)
        {
            similarity += 1;
        }

        //for every 25 frequency units away (scale 100-500), lose 1 point of similarity
        similarity -= (Mathf.Abs(input.frequency - comparison.frequency)) / 25f;
        //Debug.Log(similarity);

        int numToggles = Mathf.Min(input.toggles.Length, comparison.toggles.Length);
        for (int i = 0; i < numToggles; i++)
        {
            if (input.toggles[i] != comparison.toggles[i])
            {
                //we need all toggles to match before doing a similarity comparison
                //so if the toggles are wrong, it can never match
                //Debug.LogWarning("A toggle did not match!");

                if(similarity >= 2f)
                {
                    DialogueManager.instance?.StartDialogue(missingToggle);
                }

                return 0;
            }
        }

        return similarity;
    }

    [System.Serializable]
    public struct RadioData
    {
        public float frequency;
        public float horizontalPosition;
        public float verticalPosition;

        public bool[] toggles;
    }
}

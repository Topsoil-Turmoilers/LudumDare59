using UnityEngine;

public class RadioDialogue : MonoBehaviour
{
    [SerializeField] private RadioData[] RequiredRadioData;
    [SerializeField] private InteractionHook[] InteractionHooks;



    private float Similarity(RadioData input, RadioData comparison)
    {
        float similarity = 0;

        int numToggles = Mathf.Min(input.toggles.Length, comparison.toggles.Length);
        for(int i=0; i< numToggles; i++)
        {
            if (input.toggles[i] != comparison.toggles[i])
            {
                //we need all toggles to match before doing a similarity comparison
                //so if the toggles are wrong, it can never match
                return 0;
            }
        }

        //this code currently assumes values between 0 and 1 for each slider
        if(Mathf.Abs(input.horizontalPosition - comparison.horizontalPosition) <= 0.1f)
        {
            similarity += 1;
        }

        //this code currently assumes values between 0 and 1 for each slider
        if (Mathf.Abs(input.verticalPosition - comparison.verticalPosition) <= 0.1f)
        {
            similarity += 1;
        }

        //this code currently assumes values between 0 and 1 for each slider
        if (Mathf.Abs(input.frequency - comparison.frequency) <= 0.1f)
        {
            similarity += 1;
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

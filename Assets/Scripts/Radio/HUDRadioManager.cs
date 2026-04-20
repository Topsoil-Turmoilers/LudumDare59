using UnityEngine;

public class HUDRadioManager : MonoBehaviour
{
    [SerializeField] private PlayerMain player;
    [SerializeField] private RadioDesk radioDesk;
    [SerializeField] private MonsterTimer monsterTimer;

    [SerializeField] private Material WaveMaterial;
    [SerializeField] private float waveSize;
    [SerializeField] private float iTime;

    [SerializeField] private float radioDist;
    [SerializeField] private bool canCall;

    [SerializeField] private InteractionHook HUDRadioDialogue;
    [SerializeField] private DialogueObject noSignal;

    public void PlaceCall()
    {
        if (canCall)
        {
            player.SwitchState(player.InteractState);
            HUDRadioDialogue.OnInteract();
        }
        else
        {
            player.SwitchState(player.InteractState);
            DialogueManager.instance.StartDialogue(noSignal);
        }
    }
    private void Update()
    {
        iTime += Time.deltaTime;
        iTime %= 4f;
        
        radioDist = Vector3.Distance(player.transform.position, radioDesk.transform.position);
        canCall = radioDist >= 10 && !monsterTimer.IsMonsterTime && !player.isInside;

        if (monsterTimer.IsMonsterTime)
        {
            WaveMaterial.SetFloat("_iTime", iTime * iTime);
            WaveMaterial.SetFloat("_WaveHeight", Mathf.Sin(iTime * 2f * 3.141f) * 3f);
            WaveMaterial.SetFloat("_Frequency", (Mathf.Sin(iTime * 2f * 3.141f) * 0.5f + 0.5f)/2f + 0.25f);
        }
        else
        {
            float waveHeight = Mathf.Pow((radioDist / 10f), 2f) * 2;
            WaveMaterial.SetFloat("_iTime", iTime);
            WaveMaterial.SetFloat("_WaveHeight", Mathf.Min(2, waveHeight));
            WaveMaterial.SetFloat("_Frequency", 0.25f);
        }
    }
}

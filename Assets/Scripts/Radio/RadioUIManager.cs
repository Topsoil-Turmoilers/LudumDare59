using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadioUIManager : MonoBehaviour
{
    [SerializeField] private RadioDialogue radioDialogue;

    private Canvas radioUICanvas;

    [SerializeField] private Button PlaceCallButton;

    [SerializeField] private Slider frequencySlider;

    [SerializeField] private Slider horizontalPositionSlider;
    [SerializeField] private Slider verticalPositionSlider;

    [SerializeField] private Sprite ToggleFalse;
    [SerializeField] private Sprite ToggleTrue;

    [SerializeField] private Toggle[] Toggles;
    public bool[] ToggleValues { get
        {
            bool[] values = new bool[Toggles.Length];
            for(int i=0; i<Toggles.Length; i++)
            {
                values[i] = Toggles[i].value;
            }
            return values;
        } }

    [SerializeField] private Button CallbackButton1;
    [SerializeField] private Button CallbackButton2;
    [SerializeField] private Button CallbackButton3;
    [SerializeField] private Button CallbackButton4;
    [SerializeField] private Button CallbackButton5;

    [SerializeField] private Material FrequencyMaterial;
    [SerializeField] private Material MapMaterial;
    [SerializeField] private Material WavesMaterial;
    private float wavesTime;
    [SerializeField] private float waveHeight;
    [SerializeField] private float waveSpeedMultiplier = 5.0f;

    [SerializeField] private DialogueObject OnFirstRadioVisit;

    private RadioDialogue.RadioData RadioState;

    private void Awake()
    {
        frequencySlider.onValueChanged.AddListener(value => { 
            RadioState.frequency = frequencySlider.value;
            FrequencyMaterial.SetFloat("_MarkerPosition", RadioState.frequency);
        });
        FrequencyMaterial.SetFloat("_MarkerPosition", RadioState.frequency);

        horizontalPositionSlider.onValueChanged.AddListener(value => { 
            RadioState.horizontalPosition = value;
            MapMaterial.SetFloat("_MarkerPositionX", RadioState.horizontalPosition);
        });
        MapMaterial.SetFloat("_MarkerPositionX", RadioState.horizontalPosition);
        verticalPositionSlider.onValueChanged.AddListener(value => { 
            RadioState.verticalPosition = value;
            MapMaterial.SetFloat("_MarkerPositionY", RadioState.verticalPosition);
        });
        MapMaterial.SetFloat("_MarkerPositionY", RadioState.verticalPosition);

        for (int i = 0; i < Toggles.Length; i++)
        {
            Toggle t = Toggles[i];
            Toggles[i].SetLight();
            Toggles[i].toggleButton.onClick.AddListener(() =>
            {
                t.ToggleValue();
                RadioState.toggles = ToggleValues;
                //jank but we take those
                t.toggleButton.GetComponent<Image>().sprite = t.value ? ToggleTrue : ToggleFalse;

                if (t.value) AudioManager.instance?.PlayRadioButton01SFX();
                else AudioManager.instance?.PlayRadioButton02SFX();
            });
        }

        RadioState.toggles = new bool[Toggles.Length];

        PlaceCallButton.onClick.AddListener(() => { radioDialogue.MakeCall(RadioState); });

        CallbackButton1.onClick.AddListener(() => { radioDialogue.MakeCallBack(0); });
        CallbackButton2.onClick.AddListener(() => { radioDialogue.MakeCallBack(1); });
        CallbackButton3.onClick.AddListener(() => { radioDialogue.MakeCallBack(2); });
        CallbackButton4.onClick.AddListener(() => { radioDialogue.MakeCallBack(3); });
        CallbackButton5.onClick.AddListener(() => { radioDialogue.MakeCallBack(4); });

        radioUICanvas = GetComponentInChildren<Canvas>(true);
    }
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(PlaceCallButton.gameObject);
    }
    private void Update()
    {
        wavesTime += Time.deltaTime * waveSpeedMultiplier;
        wavesTime %= 8;
        WavesMaterial.SetFloat("_iTime", wavesTime);

        //normalize it into a 0.0 to 1.0 wave
        waveHeight = (Mathf.Cos(wavesTime / 4f * Mathf.PI) * 0.5f + 0.5f);
        //then modify it into a 0-4 height wave
        waveHeight *= 1.5f;
        waveHeight += 1f;
        
        waveHeight = Mathf.Clamp(waveHeight, 0.1f, 4f);
        WavesMaterial.SetFloat("_WaveHeight", waveHeight);
    }

    public void OpenRadioUI()
    {
        Debug.Log("Opening the Radio UI");
        radioUICanvas.gameObject.SetActive(true);

        if (!StoryFlagManager.instance.checkFlag(StoryFlagManager.StoryFlag.CheckedRadio))
        {
            DialogueManager.instance.StartDialogue(OnFirstRadioVisit);
            StoryFlagManager.instance.setFlag(StoryFlagManager.StoryFlag.CheckedRadio, true);
        }
    }
    public void CloseRadioUI()
    {
        Debug.Log("Closing the Radio UI");
        radioUICanvas.gameObject.SetActive(false);
    }

    [System.Serializable]
    public struct Toggle
    {
        public Button toggleButton;
        public Image toggleDisplay;
        public bool value;
        public void ToggleValue()
        {
            value = !value;

            SetLight();
        }
        public void SetLight()
        {
            toggleDisplay.color = value ? Color.green : Color.red;
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadioUIManager : MonoBehaviour
{
    [SerializeField] private RadioDialogue radioDialogue;

    [SerializeField] private Button PlaceCallButton;

    [SerializeField] private Slider frequencySlider;

    [SerializeField] private Slider horizontalPositionSlider;
    [SerializeField] private Slider verticalPositionSlider;

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

    private RadioDialogue.RadioData RadioState;

    private void Awake()
    {
        frequencySlider.onValueChanged.AddListener(value => { RadioState.frequency = frequencySlider.value; });

        horizontalPositionSlider.onValueChanged.AddListener(value => { RadioState.horizontalPosition = value; });
        verticalPositionSlider.onValueChanged.AddListener(value => { RadioState.verticalPosition = value; });

        for(int i = 0; i < Toggles.Length; i++)
        {
            Toggle t = Toggles[i];
            Toggles[i].SetLight();
            Toggles[i].toggleButton.onClick.AddListener(() =>
            {
                t.ToggleValue();
                RadioState.toggles = ToggleValues;
                Debug.Log(RadioState.frequency);
            });
        }

        RadioState.toggles = new bool[Toggles.Length];

        PlaceCallButton.onClick.AddListener(() => { radioDialogue.MakeCall(RadioState); });

        CallbackButton1.onClick.AddListener(() => { radioDialogue.MakeCallBack(0); });
        CallbackButton2.onClick.AddListener(() => { radioDialogue.MakeCallBack(1); });
        CallbackButton3.onClick.AddListener(() => { radioDialogue.MakeCallBack(2); });
        CallbackButton4.onClick.AddListener(() => { radioDialogue.MakeCallBack(3); });
        CallbackButton5.onClick.AddListener(() => { radioDialogue.MakeCallBack(4); });
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(PlaceCallButton.gameObject);
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

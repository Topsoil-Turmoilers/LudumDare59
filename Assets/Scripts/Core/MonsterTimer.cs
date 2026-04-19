using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MonsterTimer : MonoBehaviour
{
    public Volume screenVolume;
    public Vignette vignette;
    public float time;

    private void Start()
    {
        screenVolume.profile.TryGet<Vignette>(out vignette);
    }

    private void Update()
    {
        time += Time.deltaTime;
        //10 circles of pi
        time %= 2f * 3.141f;
        float sinTime = Mathf.Sin(time) * 0.5f + 0.5f;


        vignette.intensity.value = Mathf.Lerp(0.2f, 1.0f, sinTime);
    }
}

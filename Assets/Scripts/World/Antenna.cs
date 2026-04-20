using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] private GameObject AntennaFine;
    [SerializeField] private GameObject AntennaFallen;

    public void AntennaFallOver()
    {
        AntennaFine.SetActive(false);
        AntennaFallen.SetActive(true);
    }

    public void AntennaFixed()
    {
        AntennaFine.SetActive(true);
        AntennaFallen.SetActive(false);
    }
}

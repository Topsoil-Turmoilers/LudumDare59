using UnityEngine;

[RequireComponent (typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    public static CameraMover instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            theCamera = GetComponent<Camera>();
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] private Transform objectToTrack;
    private Camera theCamera;

    // Update is called once per frame
    void Update()
    {
        if(objectToTrack == null)
        {
            Debug.LogWarning("Camera is not set to track anything. Please set that up");
        }
        Vector2 lerpPosition = Vector2.Lerp(transform.position, objectToTrack.position, 1.0f);
        Vector3 newPosition = new Vector3(lerpPosition.x, lerpPosition.y, transform.position.z);
        theCamera.transform.position = newPosition;
    }
}

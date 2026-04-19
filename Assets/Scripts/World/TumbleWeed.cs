using UnityEngine;
using UnityEngine.Rendering;

public class TumbleWeed : MonoBehaviour
{
    //why did i put so much effort into a tumbleweed?

    //Components
    private Rigidbody2D rBody;

    //Variables
    [SerializeField] private float howMuchSpinny;
    [SerializeField] private float spinny;
    private float weedWidth;
    private float direction;

    private void Awake()
    {
        //Initialization
        rBody = GetComponent<Rigidbody2D>();
        weedWidth = transform.localScale.x;
    }

    private void Update()
    {
        //Flips based on direction
        FlipSprite(rBody.linearVelocity.x);

        //Checks if it is moving
        if (rBody.linearVelocity.x > 0.25 || rBody.linearVelocity.x < -0.25 || rBody.linearVelocity.y > 0.25 || rBody.linearVelocity.y < -0.25)
        { 
            //The Spinny
            howMuchSpinny += (Mathf.Abs(rBody.linearVelocity.x) / 2);
            howMuchSpinny += (Mathf.Abs(rBody.linearVelocity.y) / 2);
            howMuchSpinny -= 0.25f;
            if (howMuchSpinny > 360 || howMuchSpinny < 0) { howMuchSpinny = 0; }
            spinny = direction > 0 ? -howMuchSpinny : howMuchSpinny;
            transform.rotation = Quaternion.Euler(0, 0, spinny);
        }

        //It gets caught on things
        if (rBody.linearVelocity.x == 0 || rBody.linearVelocity.y == 0)
        {
            rBody.linearVelocity = new Vector2(0, 0);
        }
    }

    public void FlipSprite(float hVelocity)
    {
        if (Mathf.Abs(hVelocity) > 0.1f)
        {
            direction = hVelocity > 0 ? 1f : -1f;
            Vector3 newScale = transform.localScale;
            direction = direction > 0 ? weedWidth : -weedWidth;
            newScale.x = direction;
            transform.localScale = newScale;
        }
    }
}

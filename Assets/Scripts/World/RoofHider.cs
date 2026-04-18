using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent (typeof(CompositeCollider2D))]
public class RoofHider : MonoBehaviour
{
    private CompositeCollider2D toggleArea;
    private TilemapRenderer roofRenderer;

    private void Awake()
    {
        toggleArea = GetComponent<CompositeCollider2D>();
        roofRenderer = GetComponent<TilemapRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision.name} collided with the {roofRenderer.name} and made it hide (RoofHider.cs)");
        //layer mask 0 = nothing
        roofRenderer.renderingLayerMask = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //layer mask 1 = everything
        roofRenderer.renderingLayerMask = 1;
    }
}

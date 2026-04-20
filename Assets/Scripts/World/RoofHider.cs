using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent (typeof(CompositeCollider2D))]
public class RoofHider : MonoBehaviour
{
    private CompositeCollider2D toggleArea;
    private TilemapRenderer roofRenderer;
    private PlayerMain player;

    private void Awake()
    {
        //player = FindFirstObjectByType<PlayerMain>();
        toggleArea = GetComponent<CompositeCollider2D>();
        roofRenderer = GetComponent<TilemapRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerMain>(out PlayerMain coll))
        {
            this.player = coll;
            //Debug.Log($"{collision.name} collided with the {roofRenderer.name} and made it hide (RoofHider.cs)");

            player.isInside = true;

            //layer mask 0 = nothing
            roofRenderer.renderingLayerMask = 0;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMain>(out PlayerMain coll))
        {
            this.player = coll;
            player.isInside = false;

            //layer mask 1 = everything
            roofRenderer.renderingLayerMask = 1;
            //Debug.Log($"{collision.name} exited with the {roofRenderer.name} and made it show (RoofHider.cs)");
        }
    }
}

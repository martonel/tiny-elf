using UnityEngine;

public class SetHighlight : MonoBehaviour
{
    public Material highLightedMat;
    public Material normalMat;
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.enabled)
        {
            spriteRenderer.material = highLightedMat;
        }
    }

    private void OnDisable()
    {
        spriteRenderer.material = normalMat;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            spriteRenderer.material = normalMat;
        }
    }
}

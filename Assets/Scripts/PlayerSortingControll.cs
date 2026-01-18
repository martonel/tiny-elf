using UnityEngine;

public class PlayerSortingControl : MonoBehaviour
{
    public SpriteRenderer[] renderers;
    public int defaultOrder = 2;
    public int behindOrder = 1;
    public Animator anim;

    void Start()
    {
        // Összes sprite lekérése a Player alatt
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void HideCharacter() {
        SetSortingOrder(true);
    }

    public void SetUnhideLayer(string animName)
    {
        RestoreSorting();
    }

    // Visszaállítás Animation Eventtel, vagy saját logikával
    public void RestoreSorting()
    {
        SetSortingOrder(false);
    }

    private void SetSortingOrder(bool isHide)
    {
        foreach (var rend in renderers)
        {
            if (isHide)
            {
                rend.sortingOrder = rend.sortingOrder - 50;
            }
            else
            {
                rend.sortingOrder = rend.sortingOrder + 50;
            }
        }
    }
}

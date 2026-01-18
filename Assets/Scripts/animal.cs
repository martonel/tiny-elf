using UnityEngine;

public class animal : MonoBehaviour
{

    public bool isDestroyable = false;
    public Animator anim;
    public string animName;

    LevelElements levelElements;
    public bool startWithAnim = false;

    private Collider2D col;
    public AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        levelElements = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelElements>();
        col = GetComponent<Collider2D>();
        if (startWithAnim)
        {
            if (anim != null)
            {
                anim.Play(animName);
            }
        }

    }

    void Update()
    {
        // Egér kattintás
        if (Input.GetMouseButtonDown(0))
        {
            CheckPosition(Input.mousePosition);
        }

        // Touch (mobil)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckPosition(Input.GetTouch(0).position);
        }
    }


    void CheckPosition(Vector2 screenPosition)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (col.OverlapPoint(worldPosition))
        {
            levelElements.findAnimal();

            if (anim != null)
            {
                anim.Play(animName);
                audioSource.Play();
            }

            if (isDestroyable)
            {
                Destroy(this.gameObject);

            }
        }
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);

    } 
}

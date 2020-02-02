using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite woodleft;
    public Sprite woodright;
    public Sprite woodcenter;
    public Sprite woodsides;

    private SpriteRenderer spriteRenderer;
    public int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            ChangetheWood();
        }
    }
    void OnCollisionEnter2D(Collision2D HealthCol)
    {
        if (HealthCol.transform.tag == "Enemy")
        {
            health = health - 2;

        }
    }
    void ChangetheWood()
    {


        if (health == 1)
        {
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f) != null)//right
            {
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f) == null)//left
                {
                    spriteRenderer.sprite = woodright;//right side standing
                }
            }
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f) == null)//right
            {
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f) == null)//left
                {
                    spriteRenderer.sprite = woodcenter;//neither sides standing
                }
            }
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f) == null)//right
            {
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f) != null)//left
                {
                    spriteRenderer.sprite = woodleft;//left side standing
                }
            }
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f) != null)//Right
            {
                if (Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f) != null)//left
                {
                    spriteRenderer.sprite = woodsides;//both sides standing
                }
            }
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }
}

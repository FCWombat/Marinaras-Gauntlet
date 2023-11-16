using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusObject : MonoBehaviour
{
    bool active;
    public int health;
    public int maxHealth;
    public BoxCollider2D gridArea;
    public int millisecondsUntilActive;
    private int framesUntilActive;
    public int instanceID;
    public Sprite[] sprites;
    public Sprite activeSprite;
    // Start is called before the first frame update
    void Start()
    {
        GameObject grid1 = FindObjectOfType<grid>().gameObject;
        gridArea = grid1.GetComponent<grid>().area;
        framesUntilActive = Mathf.FloorToInt(millisecondsUntilActive * 0.1f * Time.fixedDeltaTime);
        this.tag = "InnactiveCactus";
        active = false;
        health = maxHealth;

        this.transform.position = RandomizePosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ratio = (framesUntilActive / Mathf.FloorToInt(millisecondsUntilActive * 0.1f * Time.fixedDeltaTime));
        if (active == false)
        {
            framesUntilActive--;
            if(framesUntilActive == 0)
            {
                active = true;
                this.tag = "ActiveCactus";
                this.GetComponent<SpriteRenderer>().sprite = activeSprite;
            }
            for (float i = 0; i < 7; i++)
            {
                if (ratio >= (i / 7) && ratio < (i + 1 / 7))
                {
                    GetComponent<SpriteRenderer>().sprite = sprites[7-(int)i];
                    break;
                }
            }
        }
    }
    public Vector2 RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(Mathf.Round(x), Mathf.Round(y));

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "ActiveCactus")
        {
            if (other.tag == "PlayerProjectile")
            {
                if (active == false)
                {
                    health--;
                    if (health == 0)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            if (other.tag == "Segment")
            {
                other.gameObject.GetComponent<segment>().damaged = true;
                Debug.Log("collision between segment and cactus detected");
            }

        }
        else
        {
            if (other.tag == "ActiveCactus" || other.tag == "InnactiveCactus")
            {
                if (instanceID > other.GetComponent<CactusObject>().instanceID)
                {
                    this.transform.position = RandomizePosition();
                }

            }
        }
        if (other.tag == "Food")
        {
            other.GetComponent<Apple>().RandomizePosition();
        }
    }
}

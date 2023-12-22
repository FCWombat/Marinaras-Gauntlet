using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusObject : MonoBehaviour
{
    bool everActive;
    public int health;
    public int maxHealth;
    public BoxCollider2D gridArea;
    public int inactiveMilliseconds;
    private int framesUntilActive;
    public int instanceID;
    public Sprite[] growthSprites;
    public Sprite[] explosionSprites;
    public Sprite activeSprite;
    public float vertInterval = 8;
    public float horzInterval = 8;
    // Start is called before the first frame update
    void Start()
    {
        GameObject grid1 = FindObjectOfType<grid>().gameObject;
        gridArea = grid1.GetComponent<grid>().area;
        framesUntilActive = Mathf.FloorToInt(inactiveMilliseconds * 0.1f * Time.fixedDeltaTime);
        this.tag = "InnactiveCactus";
        health = maxHealth;
        everActive = false;

        this.transform.position = RandomizePosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the cactus is not active yet
        if (everActive == false)
        {
            //get the ratio of completed frames to incompleted frames of waiting
            float ratio = 1.0f - (((float)framesUntilActive) / ((float)Mathf.FloorToInt(inactiveMilliseconds * 0.1f * Time.fixedDeltaTime)));
            //Debug.Log("framesUntilActive = " + framesUntilActive + " and denom = "+ Mathf.FloorToInt(inactiveMilliseconds * 0.1f * Time.fixedDeltaTime));
            //Debug.Log("L plus "+ratio);

            //count down the current fua
            framesUntilActive--;
            if (framesUntilActive <= 0) //if active, set sprite to active sprite
            {
                everActive = true;
                this.tag = "ActiveCactus";
                this.GetComponent<SpriteRenderer>().sprite = activeSprite;
            }
            else //otherwise, set sprite to one of growthSprites.Length growth sprites
            {
                for (float i = 0; i < growthSprites.Length; i++)
                {
                    if (ratio >= (i / ((float)growthSprites.Length)) && ratio < ((i + 1.0f) / ((float)growthSprites.Length)))
                    {
                        GetComponent<SpriteRenderer>().sprite = growthSprites[(int)i];
                        break;
                    }
                }
            }
        }
    }
    public Vector2 RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        //Debug.Log("x before round is " + x + " and y before round is " + y);
        //Debug.Log("x after round is " + (Mathf.Round(x / horzInterval) * horzInterval) + " and y after round is " + (Mathf.Round(y / vertInterval) * vertInterval));

        //Snap it to a grid
        return new Vector2(
            Mathf.Round(x / horzInterval) * horzInterval,
            Mathf.Round(y / vertInterval) * vertInterval);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if this cactus is active AND...
        if (this.tag == "ActiveCactus")
        {   //a projectile hits this cactus, explode and delete this cactus
            if (other.tag == "PlayerProjectile")
            {
                health--;
                if (health == 0)
                {
                    this.tag = "InnactiveCactus"; //notably, keep "everActive" true so it doesn't start trying to grow again
                    Debug.Log("Health was 0");
                    //play the explosion animation, then delete the object
                    StartCoroutine(ExplodeAndDeleteCoroutine());
                }
            }
            //a part of the snake is inside this cactus, cut off the snake at that segment
            if (other.tag == "Segment")
            {
                other.gameObject.GetComponent<segment>().damaged = true;
                Debug.Log("collision between segment and cactus detected");
            }

        }
        else //if the cactus is NOT YET active AND...
        {
            //if this cactus runs into an older cactus, move this cactus
            if (other.tag == "ActiveCactus" || other.tag == "InnactiveCactus")
            {
                if (instanceID > other.GetComponent<CactusObject>().instanceID)
                {
                    this.transform.position = RandomizePosition();
                }

            }
        }
        //in ANY case, if this cactus runs into food, move the food
        if (other.tag == "Food")
        {
            other.GetComponent<Apple>().RandomizePosition();
        }
    }

    //coroutine for playing the breakage animation:
    IEnumerator ExplodeAndDeleteCoroutine()
    {
        Debug.Log("Exploding");

        for (int i = 0; i < explosionSprites.Length; i++)
        {
            GetComponent<SpriteRenderer>().sprite = explosionSprites[i];
            yield return new WaitForSeconds(0.075f);
        }
        Destroy(this.gameObject);
    }
}
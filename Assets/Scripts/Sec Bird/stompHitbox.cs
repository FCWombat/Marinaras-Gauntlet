using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stompHitbox : MonoBehaviour
{
    public Boss boss;
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        boss = FindObjectOfType<Boss>();
    }

    // Fixed Update is called once per fixed-frame-rate frame
    void FixedUpdate()
    {
        if(alive == false)
        {
            Destroy(this);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Segment")
        {
            other.gameObject.GetComponent<segment>().damaged = true;
            Debug.Log("collision between segment and bird detected");
        }
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Snake>().lose();
            Debug.Log("Snake Should be Dead");
        }
        if (other.tag == "Food")
        {
            Debug.Log("Food Grabbed by Bird");
            if (other.gameObject.GetComponent<Apple>().big)
            {
                boss.health += 2;
            }
            else
            {
                boss.health++;
            }
            if (boss.health > boss.maxHealth)
            {
                boss.health = boss.maxHealth;
            }
            other.gameObject.GetComponent<Apple>().RandomizePosition();
        }
    }
}

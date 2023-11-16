using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public bool direction;
    public float speed;
    // Start is called before the first frame update
    public bool locked;
    void Start()
    {
        locked = true;
    }

    // Update is called once per frame (VARIABLE FRAME RATE)
    // Fixed Update is called once per fixed-frame-rate frame
    void Update()
    {
        float xVelocity = direction ? speed : -speed;
        if (locked == false)
        {
            transform.Translate(xVelocity * Time.deltaTime, 0f, 0f);
            Debug.Log("Feather Moving");
        }
        else
        {
            Debug.Log("Feather Locked");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Segment")
        {
            other.gameObject.GetComponent<segment>().damaged = true;
            Debug.Log("collision between segment and feather detected");
            Destroy(this.gameObject);
        }
        if (other.tag == "ProjectileLimit")
        {
           // Debug.Log("collision between wall and feather detected");
            Destroy(this.gameObject);
        }
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<Snake>().lose();
        }
    }
}

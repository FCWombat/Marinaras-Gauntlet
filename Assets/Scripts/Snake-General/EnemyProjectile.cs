using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //THIS IS THE EGGPLANT BULLET, YOU STUPID NERD
    public float speed;
    public Vector2 direction;
    public bool isRotated;
    // Start is called before the first frame update
    void Start()
    {
        isRotated = false;
    }
    public void setAngle(float angle)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
    // Update is called once per frame
    void Update()
    {
       // this.transform.position = new Vector2(this.transform.position.x+(direction.x*speed), this.transform.position.y+ (direction.y * speed));
    }
    // Fixed Update is called once per fixed-frame-rate frame
    private void FixedUpdate()
    {
        if (isRotated == false)
        {
            if(direction == Vector2.up)
            {
                setAngle(0.0f);
            }
            if (direction == Vector2.left)
            {
                setAngle(90.0f);
            }
            if (direction == Vector2.down)
            {
                setAngle(180.0f);
            }
            if (direction == Vector2.left)
            {
                setAngle(270.0f);
            }
            isRotated = true;
        }

        this.transform.position = new Vector3(
   Mathf.Round(this.transform.position.x) + speed * direction.x,
   Mathf.Round(this.transform.position.y) + speed * direction.y, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Segment")
        {
            other.gameObject.GetComponent<segment>().damaged = true;
            Debug.Log("collision between segment and bullet detected");
            Destroy(this.gameObject);
        }
        if (other.tag == "ProjectileLimit")
        {
            Debug.Log("collision between wall and bullet detected");
            Destroy(this.gameObject);
        }
        if(other.tag == "ActiveCactus")
        {
            other.gameObject.GetComponent<CactusObject>().health--;
            if(other.gameObject.GetComponent<CactusObject>().health == 0)
            {
                Destroy(other.gameObject);
              
            }
            Destroy(this.gameObject);
            
        }
        if (other.tag == "Boss")
        {
            other.gameObject.GetComponent<Boss>().bossAI.hit();
            Debug.Log("Boss Hit by eggplant");
            Destroy(this.gameObject);

        }
    }

}

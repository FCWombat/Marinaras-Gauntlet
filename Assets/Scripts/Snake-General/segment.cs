using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segment : MonoBehaviour
{
    public Vector2 segmentDirection;
    public float rotation;
    public Sprite cornerSprite;
    public Sprite straightSprite;
    public bool damaged;


    // Start is called before the first frame update
    void Start()
    {
        damaged = false;
    }
    public void setAngle(float angle)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SegmentUpdate(Transform nextSegment)
    {
        if (segmentDirection != nextSegment.GetComponent<segment>().segmentDirection)
        {
            GetComponent<SpriteRenderer>().sprite = cornerSprite;
            if (segmentDirection == Vector2.up)
            {
                if (nextSegment.GetComponent<segment>().segmentDirection == Vector2.right)
                {
                    setAngle(90.0f);
                }
                else
                {
                    setAngle(0.0f);
                }
            }
            if (segmentDirection == Vector2.left)
            {
                if (nextSegment.GetComponent<segment>().segmentDirection == Vector2.up)
                {
                    setAngle(180.0f);
                }
                else
                {
                    setAngle(90.0f);
                }
            }
            if (segmentDirection == Vector2.down)
            {
                if (nextSegment.GetComponent<segment>().segmentDirection == Vector2.left)
                {
                    setAngle(-90.0f);
                }
                else
                {
                    setAngle(180.0f);
                }
            }
            if (segmentDirection == Vector2.right)
            {
                if (nextSegment.GetComponent<segment>().segmentDirection == Vector2.down)
                {
                    setAngle(0.0f);
                }
                else
                {
                    setAngle(-90.0f);
                }
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = straightSprite;
            updateDirection();
        }
        segmentDirection = nextSegment.GetComponent<segment>().segmentDirection;
        transform.position =nextSegment.position;
    }
    public void updateDirection()
    {
        if (segmentDirection == Vector2.up)
        {
            setAngle(0.0f);

        }
        if (segmentDirection == Vector2.left)
        {
            setAngle(-90.0f);

        }
        if (segmentDirection == Vector2.down)
        {
            setAngle(180.0f);

        }
        if (segmentDirection == Vector2.right)
        {
            setAngle(90.0f);

        }
    }

}

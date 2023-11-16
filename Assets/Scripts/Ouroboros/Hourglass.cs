using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : MonoBehaviour
{
    public Transform topSand;
    public Transform bottomSand;
    public float seconds;
    public float step;
    float X;
    float Z;
    public bool done;
    public float stepsTaken;
    public Snake snake;
    // Start is called before the first frame update
    void Start()
    {
        stepsTaken = 0;
        done = false;
        X = topSand.localScale.x;
        Z = topSand.localScale.z;
        step = 4f / (seconds*20.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (done == false)
        {
            topSand.localScale = new Vector3(X, 2f-(step * stepsTaken), Z);
            bottomSand.localScale = new Vector3(X, 0f + (step * stepsTaken), Z);
            stepsTaken++;
            if(topSand.localScale.y <= 0)
            {
                done = true;
                snake.lose();
                Debug.Log("out of time");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource sounder;
    public BoxCollider2D gridArea;
    public bool big;
    public float vertInterval; 
    public float horzInterval;
    public void RandomizePosition()
    {
        int bigChecker = Random.Range(0, 10);
        big = (bigChecker == 0) ? true : false;
        if (big)
        {
            this.transform.localScale = new Vector3(30f, 30f, 1f);
        }
        else
        {
            this.transform.localScale = new Vector3(20f, 20f, 1f);
        }
        //the size of the play areas in pixels (256 x 144) says that x should have a range of 18 and y a range of 32
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        //Debug.Log("x before round is " + x + " and y before round is " + y);

        //Snap it to a grid
        /* To round a value to the closest multiple of a given interval in Unity, you can use the following recipe:
         * 1. Divide the value by the desired interval.
         * 2. Round the result to the nearest integer.
         * 3. Multiply the result by the interval to bring it back to the original scale.
         * 
         * - https://gamedev.stackexchange.com/questions/174618/round-to-the-nearest-multiple-of-0-75-in-c
         */
        //Debug.Log("x after round is " + (Mathf.Round(x / horzInterval) * horzInterval) + " and y after round is " + (Mathf.Round(y / vertInterval) * vertInterval));
        this.transform.position = new Vector3(
            Mathf.Round(x/horzInterval) * horzInterval, 
            Mathf.Round(y/vertInterval) * vertInterval,
            0.0f);


    }
    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           // RandomizePosition();
          //  sounder.Play();
          //Handled in Snake now because Freshman year Daniel is bad at coding
        }
        if (other.tag == "Segment")
        {
            RandomizePosition();
        }
        if(other.tag == "SB Stomp")
        {
            Debug.Log("SB Stomp hit eggplant");
        }
    }
}

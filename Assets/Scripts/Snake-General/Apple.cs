using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource sounder;
    public BoxCollider2D gridArea;
    public bool big;
    public void RandomizePosition()
    {
        int bigChecker = Random.Range(0, 10);
        big = (bigChecker == 0) ? true : false;
        if (big)
        {
            this.transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else
        {
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

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

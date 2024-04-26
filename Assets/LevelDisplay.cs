using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameplayVars.Get<int>("unlockedLevels"))
        {
            case 1:
                //show only the tutorial
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 2:
                //show the tutorial and cactus shmactus
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 3:
                //show the tutorial, cactus shmactus, and secretary bird
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            default:
                //show all levels
                GetComponent<SpriteRenderer>().sprite = sprites[3];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAnim : MonoBehaviour
{
    public Boss boss;
    public float anger;
    public float maxAnger;
    //public Sprite[] sprites; //must be size 8
    public float ratio;
    public SpriteRenderer angerMeter;
    // Start is called before the first frame update
    void Start()
    {
        maxAnger = boss.maxAnger;
    }

    // Update is called once per frame
    void Update()
    {
        anger = boss.anger;
        ratio = boss.angerRatio;
        for (float i = 0; i < 4; i++)
        {
            if (ratio >= (i / 4) && ratio < ((i + 1) / 4) && GetComponent<Animator>().GetInteger("AngerQuart") != (int)(i+1)) 
            {
                GetComponent<Animator>().SetInteger("AngerQuart", ((int)i)+1); //+1 to get rid of the 0-indexing and make it a quartile
                Debug.Log("AngerQuart = "+((int) i+1));
            }
        }
        angerMeter.color = new Color(ratio,1f-(ratio*ratio*ratio*ratio), 1f); //remove green using green = 1 - x^4 [0, 1]
                                                                              //add red using red = x [0, 1]

    }
}

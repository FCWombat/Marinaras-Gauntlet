using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAnim : MonoBehaviour
{
    public Boss boss;
    public float anger;
    public float maxAnger;
    public Sprite[] sprites; //must be size 8
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
        for (float i = 0; i < 8; i++)
        {
            if (ratio >= (i / 8) && ratio < (i + 1 / 8)) 
            {
                GetComponent<SpriteRenderer>().sprite = sprites[(int)i];
            }
        }
        angerMeter.color = new Color(ratio,1f, 1f);

    }
}

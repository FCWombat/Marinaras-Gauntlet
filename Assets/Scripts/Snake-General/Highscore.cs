using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;

    void Start()
    {
        value = 0;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateHighScore(int score)
    {
        value = score;
        this.GetComponent<Text>().text = "High Score: " + value.ToString();
    }
}

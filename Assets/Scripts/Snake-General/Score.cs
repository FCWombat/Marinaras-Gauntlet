using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Snake snake;
    public int score;
   // public int highscore;
    public int initialSize;
    public string TitleSceneName;
    // Start is called before the first frame update
    void Start()
    {
        score = initialSize;
        //this.GetComponent<Text>().text = "Score: " + score.ToString() + "\n";
        this.GetComponent<Text>().text = score.ToString() + "\n";
        // SceneManager.LoadScene(TitleSceneName);
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateScore()
    {
        score = snake.segments.Count;
        this.GetComponent<Text>().text = score.ToString() + "\n";
    }
}

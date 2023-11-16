using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Snake snake;
    public float anger;
    public float health;
    public float maxHealth;
    public IBossInterface bossAI;
    public int baseMillisecondsBetweenAttacks;
    public int baseFramesBetweenAttacks;
    public int maxAnger;
    public float minAnger;
    public int baseAnger;
    public float angerIncreaseFactor;
    public float angerDecreaseFactor;
    public float threshHoldForChange;
    public float angerRatio;
    public float healthRatio;
    public float snakeScore;
    // Start is called before the first frame update
    void Start()
    {
        snakeScore = snake.segments.Count;
        anger = baseAnger;
        baseFramesBetweenAttacks = Mathf.FloorToInt((1/anger)*baseMillisecondsBetweenAttacks * 10f*Time.fixedDeltaTime); // convert ms to frames
        health = maxHealth;
        
    }

    // Fixed Update is called once per fixed-frame-rate frame
    void FixedUpdate()
    {
        snakeScore = snake.segments.Count;
        angerRatio = (anger / maxAnger);
        healthRatio = (health / maxHealth);
        if (((snakeScore < threshHoldForChange/healthRatio) || snakeScore >= health*healthRatio) && anger + angerIncreaseFactor <= maxAnger)
        {
            anger += angerIncreaseFactor;
        }
        if (snakeScore > threshHoldForChange/healthRatio && anger - angerDecreaseFactor >= minAnger && !(snakeScore >= health * healthRatio))
        {
            anger -= angerDecreaseFactor;
        }
        baseFramesBetweenAttacks--;
        if (baseFramesBetweenAttacks <= 0)
        {
            baseFramesBetweenAttacks = Mathf.FloorToInt((1 / anger) * baseMillisecondsBetweenAttacks * 10f * Time.fixedDeltaTime);
            bossAI.Attack();
            Debug.Log("attack");
        }
    }
}

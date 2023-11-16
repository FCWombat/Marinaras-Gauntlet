using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Boss boss;
    public Transform maxHealthSprite;
    public float yScale;
    public float bossHealth;
    public float bossMaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth = boss.health;
        bossMaxHealth = boss.maxHealth;
        yScale = (bossHealth/bossMaxHealth) * 18.1f;

        this.transform.localScale = new Vector3(this.transform.localScale.x, yScale, this.transform.localScale.z);
        if (boss.health <= 0)
        {
            Destroy(maxHealthSprite.gameObject);
            Destroy(this.gameObject);
        }
    }
}

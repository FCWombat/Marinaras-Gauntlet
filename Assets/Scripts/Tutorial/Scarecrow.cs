using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scarecrow : MonoBehaviour, IBossInterface
{
    public Boss boss;
    public bool isHit;
    void Start()
    {
        isHit = false;
        boss.bossAI = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit == false)
        {
            GetComponent<Animator>().SetBool("isHit", false);
        }
    }
    public void Attack()
    {
        
    }
    public int getAttackParams()
    {
        return 0;
    }
    public void hit()
    {
        boss.health--;
        GetComponent<Animator>().SetBool("isHit", true);
        if (boss.health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("CS_Splash");
        }
        GetComponent<AudioSource>().Play();
    }

}

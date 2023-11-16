using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ouroboros : MonoBehaviour,IBossInterface
{
    public Boss boss;
    public controlsManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<controlsManager>();
        boss.bossAI = this;
        boss.baseFramesBetweenAttacks -= 1150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Debug.Log("Ouroboros Attacked");
        KeyCode left = manager.leftInput;
        manager.leftInput = manager.downInput;
        manager.downInput = manager.rightInput;
        manager.rightInput = manager.upInput;
        manager.upInput = left;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    public int getAttackParams()
    {
        return 0;
    }
    public void hit()
    {
        boss.health--;
        if (boss.health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Win");
        }
    }
}

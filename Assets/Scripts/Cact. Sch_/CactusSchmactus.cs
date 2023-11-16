using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CactusSchmactus : MonoBehaviour,IBossInterface
{
    public BoxCollider2D gridArea;
    public Boss boss;
    public bool isHit;
    public Transform cactusPrefab;
    public int numberofCacti;
    void Start()
    {
        numberofCacti = 0;
        isHit = false;
        boss.bossAI = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit == false)
        {
            GetComponent<Animator>().SetBool("isHit", false);
        }
    }
    public void Attack()
    {
        Transform cactus = Instantiate(this.cactusPrefab, new Vector3(100f, 100f, 0f), Quaternion.identity);
        cactus.gameObject.GetComponent<CactusObject>().gridArea = FindObjectOfType<grid>().area;
        cactus.gameObject.GetComponent<CactusObject>().instanceID = numberofCacti++;
        cactus.transform.position = cactus.GetComponent<CactusObject>().RandomizePosition();
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
            SceneManager.LoadScene("SB_Splash");
        }
        GetComponent<AudioSource>().Play();
    }

}

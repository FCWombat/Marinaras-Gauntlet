using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OuroborosTimer : MonoBehaviour
{
    public float timevalue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer(timevalue));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Ouro_Splash");
    }

}

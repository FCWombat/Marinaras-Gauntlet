using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float time;
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        ChangeToScene(NextScene, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToScene(string sceneToChangeTo, float delay)
    {
        StartCoroutine(DoChangeScene(sceneToChangeTo, delay));
    }
    IEnumerator DoChangeScene(string sceneToChangeTo, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}

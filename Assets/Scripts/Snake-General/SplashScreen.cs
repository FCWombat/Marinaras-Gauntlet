using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float time;
    public string NextScene;
    public controlsManager manager;

    // Start is called before the first frame update
    void Start()
    {
        ChangeToScene(NextScene, time);
        manager = FindObjectOfType<controlsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(manager.startInput)) {
            SceneManager.LoadScene(NextScene);
//            StopAllCoroutines(); //not necessary, apparently
        }
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

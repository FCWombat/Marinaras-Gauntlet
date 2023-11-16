using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossSelector : MonoBehaviour
{
    public string CS_Splash;
    public string SB_Splash;
    public string Ouro_Splash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            SceneManager.LoadScene(CS_Splash);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            SceneManager.LoadScene(SB_Splash);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            SceneManager.LoadScene(Ouro_Splash);
        }
    }
}

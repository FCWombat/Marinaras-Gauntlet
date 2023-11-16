using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToStartScreen : MonoBehaviour
{
    public controlsManager manager;
    public AudioClip MenuInteractionClip;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<controlsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(manager.quitInput))
        {
            SceneManager.LoadScene("Start Screen");
            manager.sounder.clip = MenuInteractionClip;
            manager.sounder.Play();
        }
    }
}

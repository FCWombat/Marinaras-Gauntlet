using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public string[] SceneNames;
    public int MenuIterator;
    public int NumberOfOptions;
    public float distanceBetweenOptions;
    public controlsManager manager;
    public AudioClip MenuInteractionClip;
    // Start is called before the first frame update
    void Start()
    {
        transform.position.Set(transform.position.x, transform.position.y, transform.position.z);
        MenuIterator = 1;
        manager = FindObjectOfType<controlsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(manager.upInput))
        {
           if(MenuIterator != 1)
            {
                MenuIterator--;
                manager.sounder.clip = MenuInteractionClip;
                manager.sounder.Play();
                updatePosition(true);
            }
        }

        else if (Input.GetKeyDown(manager.downInput))
        {
            if (MenuIterator != NumberOfOptions)
            {
                MenuIterator++;
                manager.sounder.clip = MenuInteractionClip;
                manager.sounder.Play();
                updatePosition(false);
            }
        }
        if (Input.GetKeyDown(manager.quitInput))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(manager.startInput))
        {
            string nextScene = SceneNames[MenuIterator - 1];
            SceneManager.LoadScene(nextScene);
            manager.sounder.clip = MenuInteractionClip;
            manager.sounder.Play();
        }
    }
    void updatePosition(bool trueUp)
    {
        float value = trueUp ? distanceBetweenOptions : -distanceBetweenOptions;
        transform.Translate(0.0f, value, 0.0f);
    }
}

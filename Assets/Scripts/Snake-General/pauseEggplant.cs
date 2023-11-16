using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseEggplant : MonoBehaviour
{
    public controlsManager manager;
    public float[] distanceBetweenOptions; //this modification allows there to be different distances between different options; necessary on the pause menu
    public int NumberOfOptions;
    public int MenuIterator;
    private Event e;
    public bool keyMapState;
    private KeyCode key;
    public AudioClip MenuInteractionClip;
    public bool continued;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<controlsManager>();
        MenuIterator = 1;
        continued = false;
    }

    // Update is called once per frame
    void Update()
    {
        key = KeyCode.None;
        if (Input.GetKeyDown(manager.upInput))
        {
            if (MenuIterator != 1)
            {
                MenuIterator--;
                updatePosition(true);
                manager.sounder.clip = MenuInteractionClip;
                manager.sounder.Play();
            }
        }
        else if (Input.GetKeyDown(manager.downInput))
        {
            if (!(MenuIterator >= NumberOfOptions))
            {
                MenuIterator++;
                updatePosition(false);
                manager.sounder.clip = MenuInteractionClip;
                manager.sounder.Play();
            }
            else
            {
                MenuIterator = NumberOfOptions;
            }
        }

        if (Input.GetKeyDown(manager.startInput))
        {
            switch (MenuIterator)
            {
                case 1:
                    continued = true;
                    break;
                case 2:
                    GetComponentInParent<RealPauseMenue>().snake.GetComponent<Snake>().ResetState();
                    Time.timeScale = 1;
                    AudioListener.pause = false;
                    SceneManager.LoadScene("IS");
                    break;
                case 3:
                    GetComponentInParent<RealPauseMenue>().snake.GetComponent<Snake>().ResetState();
                    Time.timeScale = 1;
                    AudioListener.pause = false;
                    SceneManager.LoadScene("Start Screen");
                    break;
                default:
                    Debug.Log("Eggplant clicked past the last option of the Game Over screen menu.");
                    break;
            }
        }
        if (Input.GetKeyDown(manager.quitInput))
        {
            manager.sounder.Play();
            SceneManager.LoadScene("Start Screen");
        }
    }

    void updatePosition(bool trueUp)
    {
        float value = trueUp ? distanceBetweenOptions[MenuIterator] : -(distanceBetweenOptions[MenuIterator-1]);
        transform.Translate(0.0f, value, 0.0f);
    }
}

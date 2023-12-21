using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public controlsManager manager;
    public float[] distanceBetweenOptions; //this modification allows there to be different distances between different options; necessary on the pause menu
    public int NumberOfOptions;
    public int MenuIterator;
    public bool keyMapState;
    public AudioClip MenuInteractionClip;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<controlsManager>();
        MenuIterator = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
            else {
                MenuIterator = NumberOfOptions;
            }
        }

        if (Input.GetKeyDown(manager.startInput))
        {
            switch (MenuIterator) {
                case 1:
                    if (!(GameplayVars.Get<string>("previousScene") == null || GameplayVars.Get<string>("previousScene") == ""))
                    {
                        SceneManager.LoadScene(GameplayVars.Get<string>("previousScene"));
                    }
                    else {
                        SceneManager.LoadScene("SelectBoss");
                    }
                    break;
                case 2:
                    SceneManager.LoadScene("Start Screen");
                    break;
                case 3:
                    SceneManager.LoadScene("Options");
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
        float value = trueUp ? distanceBetweenOptions[MenuIterator-1] : -(distanceBetweenOptions[MenuIterator - 1]);
        transform.Translate(0.0f, value, 0.0f);
    }
}

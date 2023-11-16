using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPauseMenue : MonoBehaviour
{
    public controlsManager manager;
    public GameObject pauseMenuPanel;
    public GameObject eggplant;
    public bool activated;
    public GameObject snake;
    public void Start()
    {
        activated = false;
        isPaused = false;
        manager = FindObjectOfType<controlsManager>();
    }

    private bool isPaused;
    private void Update()
    {
        if (Input.GetKeyDown(manager.quitInput))
        {
            isPaused = !isPaused;
        }
        if (isPaused && activated == false)
        {
            ActivateMenu();
            activated = true;
        }
        if(isPaused == false && activated == true)
        {
            DeactivateMenu();
            activated = false;
        }
        if(isPaused && eggplant.GetComponent<pauseEggplant>().continued == true)
        {
            eggplant.GetComponent<pauseEggplant>().continued = false;
            DeactivateMenu();
            activated = false;
            isPaused = false;
        }
    }
    void ActivateMenu()
{ 
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuPanel.SetActive(true);
        eggplant.SetActive(true);
        snake.GetComponent<Snake>().isPaused = true;
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        eggplant.SetActive(false);
        snake.GetComponent<Snake>().isPaused = false;
    }
}

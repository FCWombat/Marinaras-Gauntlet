using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public controlsManager manager;
    public int MenuIterator; //1 is tutorial, 2 is c. s., 3 is s. b., 4 is ouro
    public bool keyMapState;
    public string[] scenes;
    public AudioClip MenuInteractionClip;
    public AudioClip MenuInteractionFailedClip;
    public float leftX; public float rightX;
    public float topY; public float bottomY;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<controlsManager>();
        MenuIterator = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if enter pressed, go to the scene indicated by MenuIterator
        // ...but only if "unlocked" is equal to or greater than the number it's trying to switch to
        int unlocked = GameplayVars.Get<int>("unlockedLevels");

        if (Input.GetKeyDown(manager.startInput)){
            switch (MenuIterator)
            {
                case 2:
                    //cactus shmactus
                    if (unlocked < 2) {
                        manager.sounder.clip = MenuInteractionFailedClip;
                        manager.sounder.ignoreListenerPause = true;
                        manager.sounder.Play();
                    }
                    else {
                        SceneManager.LoadScene(scenes[1]);
                    }
                    break;
                case 3:
                    //secretary bird
                    if (unlocked < 3)
                    {
                        manager.sounder.clip = MenuInteractionFailedClip;
                        manager.sounder.ignoreListenerPause = true;
                        manager.sounder.Play();
                    }
                    else
                    {
                        SceneManager.LoadScene(scenes[2]);
                    }
                    break;
                case 4:
                    //ouroborous
                    if (unlocked < 4)
                    {
                        manager.sounder.clip = MenuInteractionFailedClip;
                        manager.sounder.ignoreListenerPause = true;
                        manager.sounder.Play();
                    }
                    else
                    {
                        SceneManager.LoadScene(scenes[3]);
                    }
                    break;
                default:
                    //tutorial
                    SceneManager.LoadScene(scenes[0]);
                    break;
            }
        }

        //depending on state of MenuIterator, interpret directional inputs
        //if right button is pressed and MenuIterator is 1 or 3, increase MenuIterator by 1
        if (Input.GetKeyDown(manager.rightInput) && (MenuIterator == 1 || MenuIterator == 3))
        {
                MenuIterator++;
                updatePosition();
                manager.sounder.clip = MenuInteractionClip;
                manager.sounder.ignoreListenerPause = true;
                manager.sounder.Play();
         }
        //if left button is pressed and MenuIterator is 2 or 4, decrease MenuIterator by 1
        if (Input.GetKeyDown(manager.leftInput) && (MenuIterator == 2 || MenuIterator == 4))
        {
            MenuIterator--;
            updatePosition();
            manager.sounder.clip = MenuInteractionClip;
            manager.sounder.ignoreListenerPause = true;
            manager.sounder.Play();
        }
        //if up bottom is pressed and MenuIterator is 3 or 4, decrease MenuIterator by 2
        if (Input.GetKeyDown(manager.upInput) && (MenuIterator == 3 || MenuIterator == 4))
        {
            MenuIterator -= 2;
            updatePosition();
            manager.sounder.clip = MenuInteractionClip;
            manager.sounder.ignoreListenerPause = true;
            manager.sounder.Play();
        }
        //if down bottom is pressed and MenuIterator is 1 or 2, increase MenuIterator by 2
        if (Input.GetKeyDown(manager.downInput) && (MenuIterator == 1 || MenuIterator == 2))
        {
            MenuIterator += 2;
            updatePosition();
            manager.sounder.clip = MenuInteractionClip;
            manager.sounder.ignoreListenerPause = true;
            manager.sounder.Play();        
        }

    }

    void updatePosition() {
        //go to the position indicated by MenuIterator
        switch (MenuIterator) {
            case 2:
                //top right
                this.transform.position = new Vector3(rightX, topY, -1.0f);
                break;
            case 3:
                //bottom left
                this.transform.position = new Vector3(leftX, bottomY, -1.0f);
                break;
            case 4:
                //bottom right
                this.transform.position = new Vector3(rightX, bottomY, -1.0f);
                break;
            default:
                //top left
                this.transform.position = new Vector3(leftX, topY, -1.0f);
                break;
        }

    }
}

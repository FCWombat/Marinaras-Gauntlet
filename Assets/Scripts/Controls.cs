using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    public controlsManager manager;
    public GameObject message;
    public Vector3 messageLocation;
    public float distanceBetweenOptions;
    public int NumberOfOptions;
    public int MenuIterator;
    private Event e;
    public bool keyMapState;
    private KeyCode key;
    public string TitleScene;
    public AudioClip MenuInteractionClip;
    void Start()
    {
        manager = FindObjectOfType<controlsManager>();
        MenuIterator = 1;
        keyMapState = false;
        key = KeyCode.None;

    }

    // Update is called once per frame
    void Update()
    {
        if (keyMapState == false)
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
                if (MenuIterator != NumberOfOptions)
                {
                    MenuIterator++;
                    updatePosition(false);
                    manager.sounder.clip = MenuInteractionClip;
                    manager.sounder.Play();
                }
            }
            if (Input.GetKeyDown(manager.startInput))
            {
                keyMapState = true;
            }
            if (Input.GetKeyDown(manager.quitInput))
            {
                manager.sounder.Play();
                SceneManager.LoadScene(TitleScene);
            }
        }
        if (keyMapState)
        {
            
            message.SetActive(true);
            foreach (KeyCode KeyEnum in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(KeyEnum))
                {
                    key = KeyEnum;
                }
            }
            Debug.Log("Dectected Key Code: " + key);
            if (key != KeyCode.Return)
            {
                switch (MenuIterator)
                {
                    case 1:
                        manager.upInput = key;
                        break;
                    case 2:
                        manager.leftInput = key;
                        break;
                    case 3:
                        manager.downInput = key;
                        break;
                    case 4:
                        manager.rightInput = key;
                        break;
                    case 5:
                        manager.shootInput = key;
                        break;
                    case 6:
                        manager.quitInput = key;
                        break;
                }
                message.SetActive(false);
                keyMapState = false;
            }
            if (MenuIterator == 7)
            {
                manager.upInput = KeyCode.W;
                manager.leftInput = KeyCode.A;
                manager.downInput = KeyCode.S;
                manager.rightInput = KeyCode.D;
                manager.shootInput = KeyCode.Space;
                manager.startInput = KeyCode.Return;
                manager.quitInput = KeyCode.Escape;
                message.SetActive(false);
                keyMapState = false;
            }
        }
        
        
        //up
        //left
        //down
        //right
        //shoot
        //pause
        //start
        //quit
        //Reset Defaults

}
    void updatePosition(bool trueUp)
    {
        float value = trueUp ? distanceBetweenOptions : -distanceBetweenOptions;
        transform.Translate(0.0f, value, 0.0f);
    }

}

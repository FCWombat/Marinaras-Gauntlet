using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class controlsManager : MonoBehaviour
{
    public KeyCode upInput;
    public KeyCode leftInput;
    public KeyCode downInput;
    public KeyCode rightInput;
    public KeyCode shootInput;
    public KeyCode pauseInput;
    public KeyCode startInput;
    public KeyCode quitInput;
    private static GameObject instance;
    public AudioSource sounder;
    public AudioClip SoundEffects;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
            upInput = KeyCode.W;
            leftInput = KeyCode.A;
            downInput = KeyCode.S;
            rightInput = KeyCode.D;
            shootInput = KeyCode.Space;
            startInput = KeyCode.Return;
            quitInput = KeyCode.Escape;
        }
        else
        {
            Destroy(gameObject);
        }

        //set unlocked levels to 1 if nothing valid is set for it yet
        if (GameplayVars.Get<int>("unlockedLevels") != 1 && GameplayVars.Get<int>("unlockedLevels") != 2 && GameplayVars.Get<int>("unlockedLevels") != 3 && GameplayVars.Get<int>("unlockedLevels") != 4) {
            GameplayVars.Set("unlockedLevels", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

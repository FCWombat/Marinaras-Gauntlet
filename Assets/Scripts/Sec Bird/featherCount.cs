using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class featherCount : MonoBehaviour
{
    public SecreteryBird bird;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "x" + bird.feathersUntilStomp.ToString() + "\n";
    }
}

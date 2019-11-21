using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        //Load the level selected in settings
        SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

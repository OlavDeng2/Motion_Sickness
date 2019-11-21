using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [Header("Motion Sickness Settings")]
    bool VRNose = false;
    bool lowFoV = false;

    [Header("References")]
    public GameObject lowFovScreen;

    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
        SetSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //get and set the settings for motion sickness
    private void LoadSettings()
    {
        VRNose = GetBool(PlayerPrefs.GetInt("VRNose"));
        lowFoV = GetBool(PlayerPrefs.GetInt("lowFoV"));
    }
   
    private bool GetBool(int value)
    {
        if(value == 0)
        {
            return false;
        }

        else if(value == 1)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //set the settings to the player
    public void SetSettings()
    {
        lowFovScreen.SetActive(lowFoV);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Manager : MonoBehaviour
{
    public string level = "level1";

    //1 = true, 0 = false
    public int VRNose = 0;
    public int lowFoV = 0;

    //save the settings after them being set in the settings screen
    public void SaveSettings()
    {
        PlayerPrefs.SetString("level", level);

        PlayerPrefs.SetInt("VRNose", VRNose);
        PlayerPrefs.SetInt("lowFoV", lowFoV);
    }
}

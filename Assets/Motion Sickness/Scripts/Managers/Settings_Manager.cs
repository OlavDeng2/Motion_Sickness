using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Manager : MonoBehaviour
{
    //1 = true, 0 = false
    public int VRNose = 0;
    public int lowFoV = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("VRNose", VRNose);
        PlayerPrefs.SetInt("lowFoV", lowFoV);
    }
}

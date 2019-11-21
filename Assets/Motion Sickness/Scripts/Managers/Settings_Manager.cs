using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Manager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    [Header("Buttons")]
    public Dropdown levelSelect;
    public Toggle virtualNoseToggle;
    public Toggle lowFovToggle;

    private string level = "level2";

    //1 = true, 0 = false
    private int VRNose = 0;
    private int lowFoV = 0;

    //save the settings after them being set in the settings screen
    public void SaveSettings()
    {
        //get the current selected level and set it
        level = levelSelect.options[levelSelect.value].text;
        PlayerPrefs.SetString("level", level);

        VRNose = BoolToInt(virtualNoseToggle.isOn);
        PlayerPrefs.SetInt("VRNose", VRNose);

        lowFoV = BoolToInt(lowFovToggle.isOn);
        PlayerPrefs.SetInt("lowFoV", lowFoV);

        CloseSettingsPanel();
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public int BoolToInt(bool value)
    {
        if (value)
        {
            return 1;
        }

        else if (!value)
        {
            return 0;
        }

        else
        {
            return 0;
        }
    }
}

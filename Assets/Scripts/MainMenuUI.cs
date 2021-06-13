using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public TextMeshProUGUI busDriver;
    public InputField numberOfPass;

    // Start is called before the first frame update
    public void StartNew()
    {
        string textCap = numberOfPass.text;
  
        MainManager.Instance.busCapacity = Int32.Parse(textCap);
        MainManager.Instance.driverName = busDriver.text;

        SceneManager.LoadScene(1);
    }
}

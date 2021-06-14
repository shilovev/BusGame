using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI driverText;
    [SerializeField]
    private TextMeshProUGUI passengersText;
    public bool isVolbaNear;
    public int badManPower;
    private int money;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        money = 0;
        // ABSTRACTION
        UpdateMoney(0); 
        if (MainManager.Instance != null)
        {
            driverText.text = "Driver: " + MainManager.Instance.driverName;  
        }
        
    }

    public void UpdateMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = "Money: " + money;
    }
    public void UpdatePassengers(int value)
    {
        passengersText.text = "Passengers: " + value;
    }

}

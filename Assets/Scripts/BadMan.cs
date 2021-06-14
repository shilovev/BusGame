using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BadMan : Man
{
    // POLYMORPHISM
    private int decreaseHappinesBySec;
    // POLYMORPHISM
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.badManPower = decreaseHappinesBySec; 
    }

    // POLYMORPHISM
    protected override void BuildingInRange()
    {
        
        if (m_Target == Bus.Instance)
        {
            // ABSTRACTION
            Pay();
            StickToBus();
            GameManager.Instance.isVolbaNear = true; 
        }
    }
}

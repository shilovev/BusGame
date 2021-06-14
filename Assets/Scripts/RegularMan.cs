using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RegularMan : Man
{
    // POLYMORPHISM
    private float happiness;

    // POLYMORPHISM
    protected override void Update()
    {
        base.Update();

        if (inBus)
        {
            if (GameManager.Instance.isVolbaNear)
            {
                // ABSTRACTION
                decreaseHappiness(GameManager.Instance.badManPower * Time.deltaTime);
            }
        }
    }
    public void decreaseHappiness(float value)
    {
        happiness -= value;
    }

    // POLYMORPHISM
    protected override void BuildingInRange()
    {
        if (m_Target == Bus.Instance)
        {
            // ABSTRACTION
            Pay();
            StickToBus();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    public static MainManager Instance { get; private set; }
    public string driverName;
    // ENCAPSULATION
    public int busCapacity
    {
        get{return _busCapacity;}
        set
        {
            if (value > 10)
            {
                _busCapacity = 10;    
            }
            else{
                _busCapacity = value;    
            }

        }

    }
    [SerializeField]
    private int _busCapacity;

    // Start is called before the first frame update
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}

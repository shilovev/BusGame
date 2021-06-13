using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance; 
    public string driverName;
    public int busCapacity;
    // Start is called before the first frame update
    private void Awake() {
        
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

}

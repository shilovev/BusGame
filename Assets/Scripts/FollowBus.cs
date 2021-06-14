using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBus : MonoBehaviour
{
    public GameObject bus;
    [SerializeField] 
    private Vector3 offset = new Vector3(-1,3,-8);

    // Update is called once per frame
    void Update()
    {
        transform.position = bus.transform.position + offset;   
    }
}

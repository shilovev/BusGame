using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    // Start is called before the first frame update
    public static Bus Instance { get; private set; }
    public int capacity {get; private set; }
    public int passQuantity {get; private set; }
    [SerializeField]
    private float speed;
    public bool move
    {
        get{ return _move;}
        set{ _move = !_move;}
    }
    private bool _move;
    private Rigidbody rigidbody;
    private void Awake()
    {
        Instance = this;
        speed = 100;
        rigidbody = GetComponent<Rigidbody>();
        if (MainManager.Instance != null)
        {
            capacity = MainManager.Instance.busCapacity;
        }
        else{
            capacity = 1; 
        }
    
        passQuantity = 0;
    }

    private void Update() {

        if (move) {
            rigidbody.AddForce(Vector3.right * speed * Time.deltaTime);    
        }
        else{
            rigidbody.velocity = Vector3.zero;
        }
        
    }
    public void addPassenger()
    {
        passQuantity += 1;   
        GameManager.Instance.UpdatePassengers(passQuantity);
    }

}

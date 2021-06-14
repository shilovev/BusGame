using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public abstract class Man : MonoBehaviour
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private float Speed = 3;
    [SerializeField]
    private int money;
    protected Bus m_Target;
    protected NavMeshAgent m_Agent;
    protected bool inBus;

    protected virtual void Update()
    {
        if (m_Target != null)
        {
            float distance = Vector3.Distance(m_Target.transform.position, transform.position);
            if ((distance < 1.0f) && (Bus.Instance.capacity > Bus.Instance.passQuantity))
            {
                m_Agent.isStopped = true;
                BuildingInRange();
            }
        }

        if (m_Target == null)
        {
            gameObject.transform.parent = null;
        }

    }

    protected abstract void BuildingInRange();
    protected virtual void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
        inBus = false;
    }

    protected virtual void Start()
    {
        SetColor(color);

    }

    private void SetColor(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }

    public virtual void GoTo(Bus target)
    {
        m_Target = target;

        if (m_Target != null)
        {
            m_Agent.SetDestination(m_Target.transform.position);
            m_Agent.isStopped = false;
        }
    }

    public virtual void GoTo(Vector3 position)
    {
        //we don't have a target anymore if we order to go to a random point.
        m_Target = null;
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }

    protected virtual void Pay()
    {
        if (money > 0)
        {

            GameManager.Instance.UpdateMoney(money);
            money = 0;
        }

    }

    protected virtual void StickToBus()
    {
        gameObject.transform.parent = Bus.Instance.transform;
        if (!inBus) 
        {
            Bus.Instance.addPassenger();
        }

        inBus = true;
    }
}

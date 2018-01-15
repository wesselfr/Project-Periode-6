﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
Team1,
Team2
}

public enum WalkDireciton
{
Left,
Right
}

public class GenericUnit : MonoBehaviour {

    [SerializeField]
    protected Team m_Team;

    protected WalkDireciton m_Direciton;

    [SerializeField]
    protected UnitData m_Data;

    [SerializeField]
    protected Vector3 m_Target;

    protected Rigidbody m_Rigidbody;

    protected float m_AttackDelay;

    protected float m_Health;
    protected float m_Speed;
    protected float m_Range;
    protected float m_AttackSpeed;

    protected bool m_Attacking = false;
    protected bool m_Walking = false;

    protected GenericUnit m_FocussedUnit;

    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private Transform m_Transform;

    /// <summary>
    /// Initializes a new unit
    /// </summary>
    /// <param name="team">In wich team is the unit spawned?</param>
    /// <param name="data">What kind of unit is gonna be spawned?</param>
    public void Initialize(Team team, UnitData data)
    {
        m_Data = data;

        m_Health = data.Health;
        m_Speed = data.Speed;
        m_Range = data.Range;
        m_AttackSpeed = data.AttackSpeed;

        m_Team = team;

        UnitStart();
    }

    private void Start()
    {
        m_Health = m_Data.Health;
        m_Speed = m_Data.Speed;
        m_Range = m_Data.Range;
        m_AttackSpeed = m_Data.AttackSpeed;

        UnitStart();
    }

    //First thing called
    void UnitStart()
    {
        
        //Initialize Directions
        if(m_Team == Team.Team1)
        {
            m_Direciton = WalkDireciton.Right;
            m_Transform.localScale.Set(m_Transform.localScale.x, m_Transform.localScale.y, m_Transform.localScale.z);
        }
        if(m_Team == Team.Team2)
        {
            m_Direciton = WalkDireciton.Left;
            m_Transform.localScale.Set(-m_Transform.localScale.x, m_Transform.localScale.y, m_Transform.localScale.z);
        }

        //Get Components
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Walking = true; 
    }

	// Update is called once per frame
	public virtual void Update () {
        if(m_Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(m_Walking == true)
        {
            Walk();
        }

        if(m_FocussedUnit != null)
        {
            AttackUnit(m_FocussedUnit);
        }
	}

    //Unit Attack Phase
    public virtual void AttackUnit(GenericUnit unit)
    {
        //If Focus is not destoryed.
        if(unit != null)
        {
            if (m_Attacking == true)
            {
                m_AttackDelay -= Time.deltaTime;
                if(m_AttackDelay <= 0)
                {
                    unit.DealDamage(m_Data.Damage);
                    m_Attacking = false;
                    Walk();
                }
            }

            //Check if focus unit is inrange.
            else
            {
                if(Vector3.Distance(transform.position, unit.transform.position) <= m_Range)
                m_Attacking = true;
                m_AttackDelay = m_Data.AttackSpeed;
            }
        }

        //Focus died.
        else
        {
            m_Attacking = false;
            m_Walking = true;
        }
    }

    //Move unit forward
    public void Walk()
    {
        m_Rigidbody.velocity = m_Target * m_Speed;
        m_Walking = true;
    }

    //Deals damage to the unit.
    public void DealDamage(float amount)
    {
        m_Health -= amount;
    }

    /// <summary>
    /// Returns the health of the unit.
    /// </summary>
    /// <returns>Unit Health</returns>
    public float GetHealth()
    {
        return m_Health;
    }

    public UnitData GetUnitData()
    {
        return m_Data;
    }

    /// <summary>
    /// Returns the team the unit is in.
    /// </summary>
    /// <returns>Other unit team</returns>
    public Team GetTeam()
    {
        return m_Team;
    }

    private void OnTriggerStay(Collider other)
    {
        //Found Unit
        if (other.tag.Contains("Unit"))
        {
            GenericUnit unit = other.GetComponent<GenericUnit>();
            if(unit.GetTeam() != m_Team)
            {
                m_FocussedUnit = unit;
            }
        }

        if (other.tag.Contains("Waypoint"))
        {
            m_Target = (other.GetComponent<Waypoints>().GetTarget(m_Direciton) - transform.position).normalized;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Contains("Waypoint"))
        {
            m_Target = collision.collider.GetComponent<Waypoints>().GetTarget(m_Direciton);
            m_Target = (m_Target - transform.position).normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Waypoint"))
        {
            m_Target = (other.GetComponent<Waypoints>().GetTarget(m_Direciton) - transform.position).normalized;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,  transform.position + m_Target);
    }
}

using System.Collections;
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
    private Team m_Team;

    private WalkDireciton m_Direciton;

    private UnitData m_Data;

    private Vector3 m_Target;

    private Rigidbody m_Rigidbody;

    private float m_AttackDelay;

    private float m_Health;
    private float m_Speed;
    private float m_Range;
    private float m_AttackSpeed;

    private bool m_Attacking = false;
    private bool m_Walking = false;

    private GenericUnit m_FocussedUnit;

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

    //First thing called
    void UnitStart()
    {
        if(m_Team == Team.Team1)
        {
            m_Direciton = WalkDireciton.Left;
        }
        if(m_Team == Team.Team2)
        {
            m_Direciton = WalkDireciton.Right;
        }

        m_Walking = true; 
    }

	// Update is called once per frame
	void Update () {
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
    public void AttackUnit(GenericUnit unit)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Contains("Waypoint"))
        {
            m_Target = collision.collider.GetComponent<Waypoints>().GetTarget(m_Direciton);
        }
    }
}

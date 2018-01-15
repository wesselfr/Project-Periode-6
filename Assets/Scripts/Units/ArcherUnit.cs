using UnityEngine;
using System.Collections;

public class ArcherUnit : GenericUnit
{

    [SerializeField]
    private Bow m_Bow;

    [SerializeField]
    private ObjectPool m_ArrowPool;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void AttackUnit(GenericUnit unit)
    {
        //If Focus is not destoryed.
        if (unit != null)
        {
            if (m_Attacking == true)
            {
                m_AttackDelay -= Time.deltaTime;
                if (m_AttackDelay <= 0)
                {
                    GameObject arrow = m_ArrowPool.GetObject();
                    Arrow arrowScript = arrow.GetComponent<Arrow>();
                    arrowScript.Damage = m_Data.Damage;
                    m_Bow.Initialize(unit.transform, arrow);
                    m_Bow.SimulateProjectile();
                    m_Attacking = false;
                    Walk();
                }
            }

            //Check if focus unit is inrange.
            else
            {
                if (Vector3.Distance(transform.position, unit.transform.position) <= m_Range)
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
}

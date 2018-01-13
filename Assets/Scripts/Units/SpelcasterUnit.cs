using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelcasterUnit : GenericUnit {

    public override void AttackUnit(GenericUnit unit)
    {
        base.AttackUnit(unit);
    }

    private void OnTriggerStay(Collider other)
    {
        //Found Unit
        if (other.tag.Contains("Unit"))
        {
            GenericUnit unit = other.GetComponent<GenericUnit>();
            if (unit.GetTeam() == m_Team)
            {
                m_FocussedUnit = unit;
            }
        }

        if (other.tag.Contains("Waypoint"))
        {
            m_Target = (other.GetComponent<Waypoints>().GetTarget(m_Direciton) - transform.position).normalized;
        }
    }
}

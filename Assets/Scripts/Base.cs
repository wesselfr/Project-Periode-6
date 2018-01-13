using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BaseEvent(Team team);
public class Base : GenericUnit {
    public BaseEvent OnBaseDestroyed;

    public override void Update()
    {
        if(m_Health <= 0)
        {
            if(OnBaseDestroyed != null)
            {
                OnBaseDestroyed(m_Team);
            }
        }
    }
}

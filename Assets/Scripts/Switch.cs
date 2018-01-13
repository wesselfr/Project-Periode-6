using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Waypoints {

    [SerializeField]
    private WalkDireciton m_SwitchDireciton;

    [SerializeField]
    private Transform[] m_SwitchPositions;

    private int m_Current = 0;

    public void Start()
    {
        if (m_SwitchDireciton == WalkDireciton.Left)
        {
            m_LeftTarget = m_SwitchPositions[m_Current];
        }
        if (m_SwitchDireciton == WalkDireciton.Right)
        {
            m_RightTarget = m_SwitchPositions[m_Current];
        }
    }
    
    public void SwitchLane()		
     {		
         m_Current++;		
         if(m_Current >= m_SwitchPositions.Length)		
         {		
             m_Current = 0;		
         }		
 		
         GetTarget(m_SwitchDireciton);		
     }

    public override Vector3 GetTarget(WalkDireciton direction)
    {
        if(m_SwitchDireciton == WalkDireciton.Left)
        {
            m_LeftTarget = m_SwitchPositions[m_Current];
        }
        if(m_SwitchDireciton == WalkDireciton.Right)
        {
            m_RightTarget = m_SwitchPositions[m_Current];
        }
        return base.GetTarget(direction);
    }
}

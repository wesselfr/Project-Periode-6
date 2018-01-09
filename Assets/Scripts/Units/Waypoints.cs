using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    [SerializeField]
    private Transform m_LeftTarget, m_RightTarget;

    public Vector3 GetTarget(WalkDireciton direction)
    {
        Vector3 target = Vector3.zero;

        if(direction == WalkDireciton.Left)
        {
            target = m_LeftTarget.position;
        }

        if(direction == WalkDireciton.Right)
        {
            target = m_RightTarget.position;
        }

        return target;
    }
}

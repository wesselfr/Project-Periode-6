using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    [SerializeField] private float m_Angle = 45.0f;
    [SerializeField] private float m_Gravity = 9.8f;
    
    [SerializeField] private Transform m_OtherTarget;
    public Transform SetArrowTarget { get { return m_OtherTarget; } private set { m_OtherTarget = value; } }
    [SerializeField] private Transform m_Arrow;
    public Transform GSArrow { get { return m_Arrow; } private set { m_Arrow = value; } }

    private Transform m_ThisTransform;

    public void Initialized(Transform otherTarget, Transform arrow)
    {
        m_OtherTarget = otherTarget;
        m_Arrow = arrow;
    }

    void Awake()
    {
        m_ThisTransform = transform;
    }

    public IEnumerator SimulateProjectile()
    {
        
        yield return new WaitForSeconds(1.5f);


        m_Arrow.position = m_ThisTransform.position + new Vector3(0, 0.0f, 0);


        float targetDistance = Vector3.Distance(m_Arrow.position, m_OtherTarget.position);


        float projectileVelocity = targetDistance / (Mathf.Sin(2 * m_Angle * Mathf.Deg2Rad) / m_Gravity);
        
        float x = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(m_Angle * Mathf.Deg2Rad);
        float y = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(m_Angle * Mathf.Deg2Rad);


        float flyingTime = targetDistance / x;


        m_Arrow.rotation = Quaternion.LookRotation(m_OtherTarget.position - m_Arrow.position);

        float elapsedTime = 0;

        while (elapsedTime < flyingTime)
        {
            m_Arrow.Translate(0, (y - (m_Gravity * elapsedTime)) * Time.deltaTime, x * Time.deltaTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}

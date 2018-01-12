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

    private Transform myTransform;
   

    public void Initialize(Transform otherTarget, Transform arrow)
    {
        m_OtherTarget = otherTarget;
        m_Arrow = arrow;
    }

    void Awake()
    {
        myTransform = transform;
    }





    public IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        m_Arrow.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(m_Arrow.position, m_OtherTarget.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * m_Angle * Mathf.Deg2Rad) / m_Gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(m_Angle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(m_Angle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        m_Arrow.rotation = Quaternion.LookRotation(m_OtherTarget.position - m_Arrow.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            m_Arrow.Translate(0, (Vy - (m_Gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}

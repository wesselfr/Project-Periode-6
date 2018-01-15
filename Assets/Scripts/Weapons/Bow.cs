using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    [SerializeField] private float m_Angle = 45.0f;
    [SerializeField] private float m_Gravity = 9.8f;
    
    [SerializeField] private Transform m_OtherTarget;
    public Transform SetArrowTarget { get { return m_OtherTarget; } private set { m_OtherTarget = value; } }
    [SerializeField] private GameObject m_Arrow;
    public GameObject GSArrow { get { return m_Arrow; } private set { m_Arrow = value; } }

    private Transform m_ThisTransform;

    public void Initialize(Transform otherTarget, GameObject arrow)
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

        GameObject arrow = Instantiate(m_Arrow, this.gameObject.transform.position, Quaternion.identity);

        arrow.transform.position = m_ThisTransform.position + new Vector3(0, 0.0f, 0);


        float targetDistance = Vector3.Distance(arrow.transform.position, m_OtherTarget.position);


        float projectileVelocity = targetDistance / (Mathf.Sin(2 * m_Angle * Mathf.Deg2Rad) / m_Gravity);
        
        float x = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(m_Angle * Mathf.Deg2Rad);
        float y = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(m_Angle * Mathf.Deg2Rad);


        float flyingTime = targetDistance / x;


        arrow.transform.rotation = Quaternion.LookRotation(m_OtherTarget.position - arrow.transform.position);

        float elapsedTime = 0;

        while (elapsedTime < flyingTime)
        {
            arrow.transform.Translate(0, (y - (m_Gravity * elapsedTime)) * Time.deltaTime, x * Time.deltaTime);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}

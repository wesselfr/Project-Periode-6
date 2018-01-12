using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float m_Damage;
    public float Damage { get { return m_Damage; } private set { m_Damage = value; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<GenericUnit>() != null)
            collision.collider.GetComponent<GenericUnit>().DealDamage(m_Damage);
    }
}

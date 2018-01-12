using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public float m_Damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<GenericUnit>() != null)
            collision.collider.gameObject.GetComponent<GenericUnit>().DealDamage(m_Damage);

        Destroy(this.gameObject);
    }
}

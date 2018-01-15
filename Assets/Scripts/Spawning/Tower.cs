using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private UnitData m_UnitData;
    private GameObject m_Arrow;

    private float m_Shooting;
    private float m_NextShot;

    public void Initialize(UnitData UD)
    {
        m_UnitData = UD;
        m_Shooting = m_UnitData.AttackSpeed;
        m_Arrow = Resources.Load("Arrow") as GameObject;
        
    }
    private void Start()
    {
        this.gameObject.AddComponent<Bow>();
        this.gameObject.GetComponent<Bow>().Initialize(GameObject.Find("ShootingRange").transform, (Resources.Load("Arrow") as GameObject));
    }

    private void Update()
    {
        if(Time.time > m_NextShot)
        {
            m_NextShot = Time.time + m_Shooting;
            this.GetComponent<Bow>().SimulateProjectile();
        }
    }
}

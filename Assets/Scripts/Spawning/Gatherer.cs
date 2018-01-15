using UnityEngine;
using System.Collections.Generic;

public class Gatherer : MonoBehaviour
{


    private GameObject m_Base;
    private List<GameObject> m_GathererTowers;
    public void GatherTowers(GameObject addGatherTower)
    {
        m_GathererTowers.Add(addGatherTower);
    }

    private float m_MoveSpeed;
    private float m_Health;
    private float m_GatheredResources;



    public void Initialize(UnitData unitData, GameObject baseHouse, List<GameObject> gatherTowers)
    {
        m_Health = unitData.Health;
        m_MoveSpeed = unitData.Speed;
        m_Base = baseHouse;
        m_GathererTowers = GameObject.Find("Team1_Spawn").GetComponent<UnitSpawner>().GathererTowers;
        m_GatheredResources = unitData.MoneyReturned;
        Gold.OnGoldRetraction += GoldRetracted;

    }
    

    private void Update()
    {
        transform.position = Vector3.Lerp(m_Base.transform.position, m_GathererTowers[1].transform.position, (Mathf.PingPong(Time.time * m_MoveSpeed, 1f)));

        if ((this.transform.position - m_Base.transform.position).magnitude < 0.1)
        {
            GoldRetracted(m_GatheredResources);    
        }
    }
        
    private void GoldRetracted(float retractAmount)
    {
        Gold.DrawGold(-retractAmount);
    }
}
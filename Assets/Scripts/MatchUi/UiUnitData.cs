using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiUnitData : MonoBehaviour, IPointerClickHandler
{
    private UnitData m_UnitData;
    
    public UnitData GetUnitData { get { return m_UnitData; } }
    public void SetUnitData(UnitData unitData)
    {
        m_UnitData = unitData;
        Gold.OnGoldRetraction += OnGold;
    }



    [SerializeField] private GameObject m_SpawnObject;
    private void Start()
    {
        m_SpawnObject = GameObject.Find("Team1_Spawn");
    }

    private void OnGold(float retractAmount)
    {
        Gold.DrawGold(retractAmount);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_UnitData.SpawnAtBase && m_UnitData.m_UnitType == UnitType.Warrior /* Cost check */)
        {
            OnGold(m_UnitData.Cost);
            SpawnObject(m_SpawnObject,m_UnitData);
        }
        if(m_UnitData.SpawnAtBase && m_UnitData.m_UnitType == UnitType.Gatherer)
        {
            OnGold(m_UnitData.Cost);
            SpawnObject(m_SpawnObject,m_UnitData);
        }
        if (!m_UnitData.SpawnAtBase && m_UnitData.m_UnitType == UnitType.Archer)
        {
            OnGold(m_UnitData.Cost);
            GameObject go = Instantiate(new GameObject(), GameObject.Find("Canvas").transform.position,Quaternion.identity);
            go.transform.parent = GameObject.Find("Canvas").transform;
            go.AddComponent<TowerUI>();
            go.GetComponent<TowerUI>().Initialized(m_UnitData,go);
        }
        if (m_UnitData.SpawnAtBase && m_UnitData.m_UnitType == UnitType.Archer)
        {
            OnGold(m_UnitData.Cost);
            SpawnObject(m_SpawnObject,m_UnitData);
        }
    }

    private void SpawnObject(GameObject spawn, UnitData unitData)
    {
        UnitSpawner.Spawn(m_SpawnObject, unitData);
    }
}

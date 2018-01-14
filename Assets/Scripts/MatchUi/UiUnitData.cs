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
    }

    private void SpawnObject(GameObject spawn, UnitData unitData)
    {
        UnitSpawner.Spawn(spawn,unitData);
    }
}

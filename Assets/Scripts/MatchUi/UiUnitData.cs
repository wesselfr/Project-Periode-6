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

    private void OnGold(float retractAmount)
    {
        Gold.DrawGold(retractAmount);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_UnitData.SpawnAtBase && m_UnitData.m_UnitType == UnitType.Warrior /* Cost check */ )
        {
            OnGold(m_UnitData.Cost);
            SpawnObject(m_UnitData.Unitprefab,m_UnitData);
        }
    }

    private void SpawnObject(GameObject spawn, UnitData unitData)
    {
        UnitSpawner.SpawnCalled();
    }
}

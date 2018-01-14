using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSpawnCall(GameObject spawn, UnitData unitData, List<GameObject> gatherTowers);

public class UnitSpawner : MonoBehaviour
{
    public static event OnSpawnCall OnSpanCalled;

    [SerializeField] private List<GameObject> m_GathererTowers;

    private static List<GameObject> m_StaticTowers;

    private void Update()
    {
        m_StaticTowers = m_GathererTowers;
    }

    public static void Spawn(GameObject spawn, UnitData unitData)
    {
        GameObject go = Instantiate(unitData.Unitprefab,spawn.transform.position,Quaternion.identity);
        
        if(unitData.m_UnitType == UnitType.Archer)
        {
            go.AddComponent<GenericUnit>().Initialize(Team.Team1,unitData);
        }
        if(unitData.m_UnitType == UnitType.Warrior)
        {
            go.AddComponent<GenericUnit>().Initialize(Team.Team1,unitData);
        }
        if (unitData.m_UnitType == UnitType.Gatherer)
        {
            go.AddComponent<Gatherer>().Initialize(unitData, spawn.gameObject, m_StaticTowers);
        }
    }
}

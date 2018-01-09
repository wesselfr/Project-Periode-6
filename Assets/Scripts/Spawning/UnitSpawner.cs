using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSpawnCall(GameObject spawn, UnitData unitData, List<GameObject> gatherTowers);

public class UnitSpawner : MonoBehaviour
{
    public static event OnSpawnCall OnSpanCalled;


    public static void SpawnCalled()
    {
        OnSpanCalled += Spawn;
    }

    public static void Spawn(GameObject spawn, UnitData unitData, List<GameObject> gatherTowers)
    {
        GameObject go = Instantiate(spawn,spawn.transform.position,Quaternion.identity);
        
        if(unitData.m_UnitType == UnitType.Archer)
        {
            go.AddComponent<GenericUnit>().Initialize(new Team(),unitData);
        }
        if(unitData.m_UnitType == UnitType.Warrior)
        {
            go.AddComponent<GenericUnit>().Initialize(new Team(),unitData);
        }
        if (unitData.m_UnitType == UnitType.Gatherer)
        {
            go.AddComponent<Gatherer>().Initialize(unitData, spawn.gameObject, gatherTowers);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSpawnCall(GameObject spawn, UnitData unitData, List<GameObject> gatherTowers);

public class UnitSpawner : MonoBehaviour
{
    public static event OnSpawnCall OnSpanCalled;

    [SerializeField] private List<GameObject> m_GathererTowers;
    public List<GameObject> GathererTowers { get { return m_GathererTowers; } }
    [SerializeField] private GameObject m_ParentTransform;

    private static List<GameObject> m_StaticTowers;
    private static GameObject m_StaticParent;

    private void Update()
    {
        m_StaticTowers = m_GathererTowers;
        m_StaticParent = m_ParentTransform;
    }

    public static void Spawn(GameObject spawn, UnitData unitData)
    {
        GameObject go = Instantiate(unitData.Unitprefab,spawn.transform.position,Quaternion.identity);
        
        if(unitData.m_UnitType == UnitType.Archer)
        {
            go.GetComponent<ArcherUnit>().Initialize(Team.Team1,unitData);
        }
        if(unitData.m_UnitType == UnitType.Warrior)
        {
            go.GetComponent<GenericUnit>().Initialize(Team.Team1,unitData);
        }
        if (unitData.m_UnitType == UnitType.Gatherer)
        {
           
            if(go.GetComponent<Gatherer>() == null)
                go.AddComponent<Gatherer>();

            go.GetComponent<Gatherer>().Initialize(unitData, spawn.gameObject, m_StaticTowers);
        }
        go.transform.parent = GameObject.Find("_Units").transform;
    }
}

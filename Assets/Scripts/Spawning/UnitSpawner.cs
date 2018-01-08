using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSpawnCall(GameObject spawn, UnitData unitData);

public class UnitSpawner : MonoBehaviour
{
    private void Start()
    {
        OnSpawnCall onSpawnCall = new OnSpawnCall(Spawn);
    }

    private void Spawn(GameObject spawn, UnitData unitData)
    {
        GameObject go = Instantiate(spawn,this.gameObject.transform.position,Quaternion.identity);
        
        if(unitData.m_UnitType == UnitType.Archer)
        {

        }

    }
}

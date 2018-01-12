using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lightning : MonoBehaviour
{
    private float m_Damage;
    [SerializeField]private GameObject m_FallingObject;
    private UnitData m_UnitData;

    private void Initialize(UnitData unitData)
    {
        m_UnitData = unitData;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray,out hit))
        {
            if (hit.collider.GetComponent<GenericUnit>() != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                CalculateSpawnPosition(hit.collider.gameObject);
            }
        }
    }

    private void CalculateSpawnPosition(GameObject hitObject)
    {
        GameObject go = Instantiate(m_FallingObject,new Vector3(hitObject.transform.position.x,hitObject.transform.position.y + 10,hitObject.transform.position.z),Quaternion.identity);
        go.transform.position = new Vector3(hitObject.transform.position.x, hitObject.transform.position.y + 10, hitObject.transform.position.z);
        if (go.GetComponent<Rigidbody>() == null)
            go.AddComponent<Rigidbody>();
        if (go.GetComponent<LightningBolt>() != null)
            go.AddComponent<LightningBolt>();

        //go.GetComponent<LightningBolt>().m_Damage = m_UnitData.Damage;
    }
}

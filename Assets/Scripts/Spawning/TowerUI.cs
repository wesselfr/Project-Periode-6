using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerUI : MonoBehaviour
{
    private Sprite m_Image;
    private GameObject m_UiItem;
    private GameObject m_Tower;
    private UnitData m_UnitData;

    public void Initialized(UnitData unitData,GameObject uiItem)
    {
        m_UnitData = unitData;
        m_Image = m_UnitData.UiImage;
        m_Tower = m_UnitData.Unitprefab;

        m_UiItem = uiItem;

        m_UiItem.AddComponent<Image>();
        m_UiItem.GetComponent<Image>().sprite = m_Image;
        m_UiItem.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
  
    private void Update()
    {
        m_UiItem.transform.position = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray,out hit))
        {
            if (hit.collider.gameObject.name == "PlacableTowerSpot")
                InstantiateTower(m_Tower, hit.collider.gameObject);
        }

    }
    private void InstantiateTower(GameObject tower,GameObject hit)
    {
        GameObject go = Instantiate(tower, hit.transform.position, Quaternion.identity);
        go.AddComponent<Tower>();
        go.GetComponent<Tower>().Initialize(m_UnitData);
        Destroy(hit);
        Destroy(this.gameObject);
    }
}

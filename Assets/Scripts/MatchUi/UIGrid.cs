using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGrid : MonoBehaviour
{

    [SerializeField] private List<UnitData> m_Elements;

    private void Start()
    {
        for (int i = 0; i < (m_Elements.Count); i++)
        {
            GameObject go = Instantiate(new GameObject(), new Vector3(transform.position.x + (i * 100), transform.position.y, transform.position.z), Quaternion.identity);
            go.transform.parent = transform;
            go.AddComponent<UiUnitData>();
            go.AddComponent<Image>();
            go.GetComponent<UiUnitData>().SetUnitData(m_Elements[i]);

            go.GetComponent<Image>().sprite = go.GetComponent<UiUnitData>().GetUnitData.UiImage;
        }
    }
}

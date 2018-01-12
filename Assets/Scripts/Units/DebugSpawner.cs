using UnityEngine;
using System.Collections;

public class DebugSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject m_Prefab;

    [SerializeField]
    private Team m_Team;

    [SerializeField]
    private UnitData m_Data;

    [SerializeField]
    private KeyCode m_Key;

    // Use this for initialization
    void Start()
    {
        if(m_Data == null)
        {
            m_Data = new UnitData();
            m_Data.Health = 20;
            m_Data.Speed = 2;
            m_Data.Range = 2;
            m_Data.Damage = 4;
            m_Data.AttackSpeed = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(m_Key))
        {
            GameObject unitObject = Instantiate(m_Prefab, transform.position, Quaternion.identity);
            GenericUnit unit = unitObject.GetComponent<GenericUnit>();
            unit.Initialize(m_Team, m_Data);
        }
    }
}

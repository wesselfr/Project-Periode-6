using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    private GameObject m_ObjectToPool;

    [SerializeField]
    private int m_Lenght;

    private Stack<GameObject> m_ObjectPool;

    public void Start()
    {
        m_ObjectPool = new Stack<GameObject>(m_Lenght);
        for(int i = 0; i < m_Lenght; i++)
        {
            m_ObjectPool.Push(Instantiate(m_ObjectToPool, transform));
        }
    }

    /// <summary>
    /// Return Object from pull.
    /// </summary>
    /// <returns>GameObject</returns>
    public GameObject GetObject()
    {
        return m_ObjectPool.Pop();
    }

    public void AddUnitBackToPool(GameObject _obj)
    {
        //Prevents other objects in same pool
        if (_obj.name.Contains(m_ObjectToPool.name))
        {
            _obj.transform.parent = transform;
            m_ObjectPool.Push(_obj);
        }
    }
}

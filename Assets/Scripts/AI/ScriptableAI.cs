using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/AI")]
public class ScriptableAI : ScriptableObject
{
    [Header("floats")]
    [SerializeField]
    private float m_BaseHealth;
    public float GetBaseHealth { get { return m_BaseHealth; } }
    [SerializeField] private float m_SpawnRate;
    public float GetSpawnRate { get { return m_SpawnRate; } }
    private float m_NextSpawn;
    public float GetNextSpawn { get { return m_NextSpawn; } }

    [Header("Ammunition")]
    [SerializeField]
    private List<GameObject> m_EnemyTypes;
    public List<GameObject> GetEnemyType { get { return m_EnemyTypes; } }
}

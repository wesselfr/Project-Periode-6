using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    [SerializeField] private ScriptableAI m_AIDifficulty;
    [SerializeField] private GameObject m_SpawnPoint;

    private float m_SpawnRate;
    private float m_NextSpawn;

    private List<GameObject> m_Enemies;

    private void Start()
    {
        m_SpawnRate = m_AIDifficulty.GetSpawnRate;
        m_NextSpawn = m_AIDifficulty.GetNextSpawn;

        m_Enemies = m_AIDifficulty.GetEnemyType;
    }

    private void Update()
    {
        if (Time.time > m_NextSpawn)
        {
            m_NextSpawn = Time.time + m_SpawnRate;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject go = Instantiate(m_Enemies[Random.Range(0, m_Enemies.Count)], m_SpawnPoint.transform.position,Quaternion.identity);
    }
}

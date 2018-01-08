using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
Team1,
Team2
}

public enum WalkDireciton
{
Left,
Right
}

public class GenericUnit : MonoBehaviour {

    [SerializeField]
    private Team m_Team;

    private UnitData m_Data;

    private float m_Health;
    private float m_Speed;
    private float m_Range;
    private float m_AttackSpeed;

    public void Initialize(Team team, UnitData data)
    {
        m_Health = data.Health;
        m_Speed = data.Speed;
        m_Range = data.Range;
        m_AttackSpeed = data.AttackSpeed;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

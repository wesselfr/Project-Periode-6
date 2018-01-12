using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private GenericUnit m_Unit;

    private float m_MaxHealth;

    [SerializeField]
    private Image m_Bar;

    [SerializeField]
    private Text m_BarText;

	// Use this for initialization
	void Start () {
        m_MaxHealth = m_Unit.GetUnitData().Health;
	}
	
	// Update is called once per frame
	void Update () {

        float health = m_Unit.GetHealth();

        m_Bar.fillAmount = health / m_MaxHealth;

        if(m_BarText != null)
        {
            m_BarText.text = health + "/" + m_MaxHealth;
        }

	}
}

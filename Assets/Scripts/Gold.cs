using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OngoldRetraction(float retractAmount);

public class Gold : MonoBehaviour
{
    [SerializeField] private float m_Gold;
    public void SetGold(float newGold)
    {
        m_Gold = newGold;
    }
    [SerializeField] private Text m_Text;

    private void Start()
    {
        OngoldRetraction gold = new OngoldRetraction(DrawGold);
    }

    private void DrawGold(float retractAmount)
    {
        m_Gold -= retractAmount;
        m_Text.text = "Gold: " + m_Gold;
    }
}

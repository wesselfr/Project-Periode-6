﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OngoldRetraction(float retractAmount);

public class Gold : MonoBehaviour
{
    public static event OngoldRetraction OnGoldRetraction;

    [SerializeField] private static float m_Gold = 1000;
    public void SetGold(float newGold)
    {
        m_Gold = newGold;
    }
    [SerializeField] private static Text m_Text;
    
    private void Start()
    {
        m_Text = GameObject.Find("Gold").GetComponent<Text>();
        m_Text.text = "Gold: " + m_Gold;
    }

    public static void DrawGold(float retractAmount)
    {
        
        m_Gold -= retractAmount;
        m_Text.text = "Gold: " + m_Gold;
    }
}

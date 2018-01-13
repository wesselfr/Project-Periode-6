using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseScreen : MonoBehaviour
{

    [SerializeField]
    Image m_Background;

    [SerializeField]
    Text m_Text;

    [SerializeField]
    Team m_PlayerTeam;

    [SerializeField]
    Base m_Base1, m_Base2;

    // Use this for initialization
    void Start()
    {
        //Disable panel and text.
        m_Background.enabled = false;
        m_Text.enabled = false;

        //Setup listeners.
        m_Base1.OnBaseDestroyed += OnBaseDestroyed;
        m_Base2.OnBaseDestroyed += OnBaseDestroyed;
    }

    /// <summary>
    /// Called when a base is destroyed
    /// </summary>
    /// <param name="team"></param>
    void OnBaseDestroyed(Team team)
    {
        //Lose
        if(m_PlayerTeam == team)
        {
            m_Background.enabled = true;
            m_Text.color = Color.red;
            m_Text.text = "YOU LOSE";
            m_Text.enabled = true;
        }
        //Win
        if(m_PlayerTeam != team)
        {
            m_Background.enabled = true;
            m_Text.color = Color.green;
            m_Text.text = "YOU WIN";
            m_Text.enabled = true;
        }
    }
}

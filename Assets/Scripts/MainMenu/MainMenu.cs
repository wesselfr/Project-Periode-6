using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button m_Start;
    [SerializeField] private Button m_Quit;
    [SerializeField] private GameObject m_AreYouSure;
    [SerializeField] private Button m_Yes, m_No;

    private void Start()
    {
        Button start = m_Start.GetComponent<Button>();
        start.onClick.AddListener(StartClicked);

        Button quit = m_Quit.GetComponent<Button>();
        quit.onClick.AddListener(QuitClicked);

        Button yes = m_Yes.GetComponent<Button>();
        yes.onClick.AddListener(YesClicked);

        Button no = m_No.GetComponent<Button>();
        no.onClick.AddListener(NoClicked);
    }

    private void StartClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    private void QuitClicked()
    {
        m_AreYouSure.SetActive(true);
        m_Start.gameObject.SetActive(false);
        m_Quit.gameObject.SetActive(false);
    }

    private void YesClicked()
    {
        Application.Quit();
    }

    private void NoClicked()
    {
        m_AreYouSure.SetActive(false);
        m_Start.gameObject.SetActive(true);
        m_Quit.gameObject.SetActive(true);
    }
}

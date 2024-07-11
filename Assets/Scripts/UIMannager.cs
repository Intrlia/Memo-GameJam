using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;  // ��Ҫ���غ����¼��س���
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startPage;  // ��ʼ��Ϸҳ��
    public GameObject endPage;    // ������Ϸҳ��
    public GameObject pausePage;


    private SceneFader sceneFader;
    private float timeScale;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() {
        SceneManager.LoadScene("StartGame");
    }

    void Start()
    {
        //ShowStartPage();  // ��ʼ��Ϸʱ��ʾ��ʼҳ��
        sceneFader = FindObjectOfType<SceneFader>();
        timeScale = Time.timeScale;
        //Debug.Log("start " + timeScale);
        Button[] buttons = GameObject.Find("Canvas").GetComponent<Canvas>().GetComponentsInChildren<Button>();
        if (buttons != null && buttons.Length > 2)
            buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = "��" + Time.timeScale;
    }

    public void ShowStartPage()
    {
        startPage.SetActive(true);
        endPage.SetActive(false);
    }

    public void StartGame()
    {;
        sceneFader.LoadScene("SampleScene");
    }

    public void ShowEndPage()
    {
        startPage.SetActive(false);
        endPage.SetActive(true);
    }

    public void RestartGame()
    {
        //Debug.Log(Time.timeScale + "-" + timeScale);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = timeScale;
        //timeScale = Time.timeScale;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Button button = clickedButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ContinueGame);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null) {
            buttonText.text = "Continue";
        }
        //pausePage.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = timeScale;
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Button button = clickedButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(PauseGame);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null) {
            buttonText.text = "Pause";
        }
        //pausePage.SetActive(false);
    }

    public void DoubleSpeedGame()
    {
        if (Time.timeScale != 0) {
            Time.timeScale = 2;
        }
        timeScale = 2;
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Button button = clickedButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(SingleSpeedGame);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null) {
            buttonText.text = "��2";
        }
    }

    public void SingleSpeedGame()
    {
        if (Time.timeScale != 0) {
            Time.timeScale = 1;
        }
        timeScale = 1;
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Button button = clickedButton.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(DoubleSpeedGame);
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null) {
            buttonText.text = "��1";
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

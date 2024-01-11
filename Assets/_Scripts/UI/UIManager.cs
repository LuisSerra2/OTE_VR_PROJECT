using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : Singleton<UIManager> {

    public TextMeshProUGUI waveCounterText;

    [Space]

    [Header("Win_Lose")]
    [SerializeField] private RectTransform win_losePanel;
    [SerializeField] private TextMeshProUGUI win_loseText;
    private bool teste = false;

    private void Update()
    {
        if (teste) {
            win_losePanel.localPosition = Vector3.Lerp(win_losePanel.localPosition, Vector3.zero, 3f * Time.deltaTime);
        }
    }

    #region MainMenuScene
    public void ExitGame() {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void PlayGame() {
        Debug.Log("Playing...");
        SceneManager.LoadScene("ProtectTheDoor");
    }
    public void GoToTrainingGrounds() {
        Debug.Log("Training...");
        SceneManager.LoadScene("TrainningGround");
    }

    #endregion

    #region WaveScene

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetScene() {
        SceneManager.LoadScene("ProtectTheDoor");
    }

    public void UpdateText(string text)
    {
        win_loseText.text = text;
        win_losePanel.gameObject.SetActive(true);
        teste = true;
    }

    #endregion
}

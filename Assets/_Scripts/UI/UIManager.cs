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

    public int TrainingScore = 0;

    public string rank;

    private void Update()
    {
        if (teste) {
            win_losePanel.localPosition = Vector3.Lerp(win_losePanel.localPosition, Vector3.zero, 3f * Time.deltaTime);
        }

        switch (TrainingScore)
        {
            case 0:
                rank = "Noob";
                break;
            case 5:
                rank = "Dull";
                break;
            case 10:
                rank = "Cool";
                break;
            case 15:
                rank = "Crazy";
                break;
            case 20:
                rank = "Badass";
                break;
            case 25:
                rank = "Brutal";
                break;
            case 30:
                rank = "Atomic";
                break;
            case 35:
                rank = "Stylish";
                break;
            case 40:
                rank = "Savage";
                break;
            case 45:
                rank = "Boss";
                break;
            case 50:
                rank = "Gigachad";
                break;
        }

        Debug.Log(rank);
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

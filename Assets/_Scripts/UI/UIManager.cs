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


    [Header("Training Ground")]
    [SerializeField] private TextMeshProUGUI trainingGroundText;
    public int TrainingScore = 0;
    public string rank;


    private void Update() {
        if (teste) {
            win_losePanel.localPosition = Vector3.Lerp(win_losePanel.localPosition, Vector3.zero, 3f * Time.deltaTime);
        }

        if (trainingGroundText != null) {
            HadleRanks();
        }
    }

    #region MainMenuScene
    public void ExitGame() {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene("Wave8");
    }
    public void GoToTrainingGrounds() {
        SceneManager.LoadScene("TrainningGround");
    }

    #endregion

    #region Wave8Scene

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetWave8Scene() {
        SceneManager.LoadScene("Wave8");
    }
    public void ResetWave12Scene() {
        SceneManager.LoadScene("Wave12");
    }
    public void ResetWave16Scene() {
        SceneManager.LoadScene("Wave16");
    }
    public void ResetWave20Scene() {
        SceneManager.LoadScene("Wave20");
    }
    public void ResetWave24Scene() {
        SceneManager.LoadScene("Wave24");
    }
    public void ResetWave30Scene() {
        SceneManager.LoadScene("Wave30");
    }

    public void UpdateText(string text) {
        win_loseText.text = text;
        win_losePanel.gameObject.SetActive(true);
        teste = true;
    }

    #endregion

    #region Training Ground

    private void HadleRanks() {
        switch (TrainingScore) {
            case 0:
                rank = "Noob";
                UpdateRankText();
                break;
            case 5:
                rank = "Dull";
                UpdateRankText();
                break;
            case 10:
                rank = "Cool";
                UpdateRankText();
                break;
            case 15:
                rank = "Crazy";
                UpdateRankText();
                break;
            case 20:
                rank = "Badass";
                UpdateRankText();
                break;
            case 25:
                rank = "Brutal";
                UpdateRankText();
                break;
            case 30:
                rank = "Atomic";
                UpdateRankText();
                break;
            case 35:
                rank = "Stylish";
                UpdateRankText();
                break;
            case 40:
                rank = "Savage";
                UpdateRankText();
                break;
            case 45:
                rank = "Boss";
                UpdateRankText();
                break;
            case 50:
                rank = "Gigachad";
                UpdateRankText();
                break;
        }
    }

    private void UpdateRankText() {
        trainingGroundText.text = "Hitting Moving Targets : " + TrainingScore + "\nRank: " + rank;
    }
    #endregion
}

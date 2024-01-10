using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : Singleton<UIManager> {

    public TextMeshProUGUI waveCounterText;

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

    #endregion
}

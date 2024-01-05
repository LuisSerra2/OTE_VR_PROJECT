using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : Singleton<UIManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void PlayGame()
    {
        Debug.Log("Playing...");
        SceneManager.LoadScene("ProtectTheDoor");
    }
    public void GoToTrainingGrounds()
    {
        Debug.Log("Training...");
    }
}

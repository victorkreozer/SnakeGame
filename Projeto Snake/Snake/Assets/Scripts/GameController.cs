using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject gameOverPanel;

    public static bool isPaused = false;
    private static GameObject gameOverPanelStatic;

    public static void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public static void FailGame() {
        gameOverPanelStatic.SetActive(true);
        isPaused = true;
        SceneManager.LoadScene("GameOverScene");
    }

    public static void RestartSoloGame() {
        SceneManager.LoadScene("SoloGame");
    }

    public static void RestartDuosGame() {
        SceneManager.LoadScene("DuosGame");
    }

    public static void ExitGame() {
        Application.Quit();
    }

    private void Awake() {
        if (gameOverPanelStatic == null) {
            gameOverPanelStatic = gameOverPanel;
        }

        isPaused = false;
    }

    private void Start() {
        var buttons = gameOverPanel.GetComponentsInChildren<Button>();

        var restartSoloBtn = (Button)(from b in buttons where b.name.Contains("RestartSolo") select b).First();
        restartSoloBtn.onClick.AddListener(() => {
            GameController.RestartSoloGame();
        });

        var restartDuosBtn = (Button)(from b in buttons where b.name.Contains("RestartDuos") select b).First();
        restartDuosBtn.onClick.AddListener(() => {
            GameController.RestartDuosGame();
        });

        var exitBtn = (Button)(from b in buttons where b.name.Contains("Exit") select b).First();
        exitBtn.onClick.AddListener(() => {
            GameController.MainMenu();
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
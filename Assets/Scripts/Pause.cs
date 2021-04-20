using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    
    public GameObject pauseMenu;

    public bool isPaused = false;

    public Button play;
    public Button options;
    public Button quit;

    public void Start() {
        // Initialize Buttons
        play = GameObject.Find("ContinueButton").GetComponent<Button>();
        play.onClick.AddListener(ContinueGame);

        options = GameObject.Find("OptionsButton").GetComponent<Button>();
        options.onClick.AddListener(Options);

        quit = GameObject.Find("QuitButton").GetComponent<Button>();
        quit.onClick.AddListener(Quit);

        pauseMenu.SetActive(false);
    }
    public void Update() {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && GameManager.numberOfLives > 0) {
            if (isPaused) {
                ContinueGame();
            }else {
                PauseGame();
            }
        }
    }
    public void ContinueGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Options() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
    }
    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

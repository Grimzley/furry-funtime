using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;

    public Button tryAgain;
    public Button quit;

    public void Start() {
        tryAgain = GameObject.Find("TryAgainButton").GetComponent<Button>();
        tryAgain.onClick.AddListener(TryAgain);

        quit = GameObject.Find("QuitButton").GetComponent<Button>();
        quit.onClick.AddListener(Quit);

        gameOverScreen.SetActive(false);
    }
    public void Update() {
        if (GameManager.numberOfLives == 0) {
            gameOverScreen.SetActive(true);
        }
    }
    public void TryAgain() {
        GameManager.Reset();
        SceneManager.LoadScene("Level1");
    }
    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

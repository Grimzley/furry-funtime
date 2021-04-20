using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public Button playAgain;
    public Button quit;

    public void Start() {
        // Initialize Buttons
        playAgain = GameObject.Find("PlayAgainButton").GetComponent<Button>();
        playAgain.onClick.AddListener(PlayAgain);

        quit = GameObject.Find("QuitButton").GetComponent<Button>();
        quit.onClick.AddListener(Quit);
    }
    public void PlayAgain(){
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

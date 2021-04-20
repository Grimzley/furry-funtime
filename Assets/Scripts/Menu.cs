using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button play;
    public Button options;
    public Button quit;
    
    public void Start() {
        // Initialize Buttons
        play = GameObject.Find("PlayButton").GetComponent<Button>();
        play.onClick.AddListener(Play);

        options = GameObject.Find("OptionsButton").GetComponent<Button>();
        options.onClick.AddListener(Options);

        quit = GameObject.Find("QuitButton").GetComponent<Button>();
        quit.onClick.AddListener(Quit);
    }
    public void Play() {
        SceneManager.LoadScene(GameManager.currentLevel + 1) ;
    }
    public void Options() {
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

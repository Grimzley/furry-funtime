using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public static int currentLevel = 2;
    public static int numberOfLives = 3;
    public static int numberOfGems = 0;

    public static bool isFullscreen = true;
    public static int graphicsIndex = 0;
    public static int resolutionIndex = -1;
    public static float volume = -20f;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }else {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }
    public static void OnGemPickUp() {
        numberOfGems++;
        if (numberOfGems == 5) {
            numberOfGems = 0;
            numberOfLives++;
        }
    }
    public static void Death() {
        numberOfLives--;
    }
    public static void NextLevel() {
        currentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

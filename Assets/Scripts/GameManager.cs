using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    // In-Game Data
    public static int currentLevel = 1;
    public static int numberOfLives = 5;
    public static int numberOfGems = 0;

    // Options Settings
    public static bool isFullscreen = true;
    public static int graphicsIndex = 0;
    public static int resolutionIndex = -1;
    public static float volume = -20f;

    // Singleton Pattern
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
        if (numberOfGems == 3) {
            numberOfGems = 0;
            numberOfLives++;
        }
    }
    public static void Death() {
        numberOfLives--;
    }
    public static void Reset() {
        currentLevel = 1;
        numberOfLives = 5;
        numberOfGems = 0;
    }
    public static void NextLevel() {
        currentLevel++;
    }
}

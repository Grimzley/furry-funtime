using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour {

    public TMP_Text levelText;
    public TMP_Text livesText;
    public TMP_Text gemsText;

    void Start() {
        levelText = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        livesText = GameObject.Find("LivesText").GetComponent<TMP_Text>();
        gemsText = GameObject.Find("GemsText").GetComponent<TMP_Text>();
    }
    void Update() {
        levelText.text = "Level: " + GameManager.currentLevel;
        livesText.text = "Lives: " + GameManager.numberOfLives;
        gemsText.text = "Gems: " + GameManager.numberOfGems;
    }
}

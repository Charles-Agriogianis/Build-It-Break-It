using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int blocksLeft = 7;
    public GameObject gameOverScreen;
    public Text gameOverText;
    public Text scoreText;
    public Text blocksLeftText;
    
    void Start() {
    }

    void Update() {
        blocksLeftText.text = "Blocks left to destroy: " + blocksLeft;
        // Check if game is over (out of ammo, or all placed blocks destroyed)
        if (mode.currentMode == 2) { // 2 is for breakmode
            if (blocksLeft <= 0) {
                LevelComplete();
            } else if (OutOfAmmo()) {
                LevelFailure();
            }
        } 
    }

    private void LevelComplete() {
        // Display GameOver screen with score based on ammo left
        int score = Pistol.GetAmmoCount() + Cannon.GetAmmoCount() * 5 + Shotgun.GetAmmoCount() / 5;
        timer.gameOver = true;
        gameOverText.text = "Good job!";
        scoreText.text = "Score: " + score;
    }

    private void LevelFailure() {
        int score = 0;
        timer.gameOver = true;
        gameOverText.text = "Out of ammo!";
        scoreText.text = "Score: " + score;
    }

    private bool OutOfAmmo() {
        return Pistol.GetAmmoCount() == 0 && Cannon.GetAmmoCount() == 0 && Shotgun.GetAmmoCount() == 0;
    }
}

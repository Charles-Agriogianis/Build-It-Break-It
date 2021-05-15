using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public static int startTime;
    public static int currentTime;
    public static bool gameOver = false;
    public Text time;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        startTime = (int) Time.time;
    }

    public static void Reset() {
        startTime = (int) Time.time;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            return;
        }

        // Do nothing if build mode
        if (mode.currentMode == 1) {
            return;
        }

        time.text = "Time Left: " + currentTime.ToString();
        currentTime = 45 - ((int)Time.time - startTime);

        if (Input.GetKeyDown(KeyCode.Return)) {
            currentTime = 0;
        }

        // break mode
        if (currentTime <= 0 && gameOver == false && mode.currentMode == 2) {
            currentTime = 0;
            gameOver = true;
            gameOverText.text = "Ran out of time";
            //mode.scores[mode.currentLevel] = scoreVariable;
        }

        // build/break mode
        if (currentTime <= 0 && mode.currentMode == 0) {
            // check if build height was reached
            bool passed = buildHeightCheck.buildHeightReached;

            // Move onto break phase
            if (passed) {
                mode.currentMode = 2;
                startTime = (int)Time.time;
            } else {
                // game over screen
                gameOver = true;
                gameOverText.text = "Build height not reached";
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalBallCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counterText;
    private int countedBalls;
    private void OnEnable() {
        GameManager.BallCounted += GameManager_BallCounted;
        GameManager.GameFinish += GameManager_GameFinish;
        GameManager.NextLevelStarted += GameManager_NextLevelStarted;
        GameManager.RestartLevelStarted += GameManager_RestartLevelStarted;
    }

    private void GameManager_RestartLevelStarted() {
        countedBalls = 0;
    }

    private void GameManager_NextLevelStarted() {
        countedBalls = 0;
    }

    private void GameManager_GameFinish() {
        if(GameManager.Instance.levels[GameManager.Instance.currentLevel].requiredBallToNext <= countedBalls) {
            counterText.text = "Congratulations!";
            GameManager.Instance.OnNextLevel();
        }
        else {
            counterText.text = "Game Over!";
            GameManager.Instance.OnRestartLevel();
        }
    }

    private void GameManager_BallCounted(int obj) {
        countedBalls = obj;
        counterText.text = countedBalls.ToString() + "/" + GameManager.Instance.levels[GameManager.Instance.currentLevel].requiredBallToNext.ToString() + "counted!";
    }
    private void OnDisable() {
        GameManager.BallCounted -= GameManager_BallCounted;
        GameManager.GameFinish -= GameManager_GameFinish; 
        GameManager.NextLevelStarted -= GameManager_NextLevelStarted; 
        GameManager.RestartLevelStarted -= GameManager_RestartLevelStarted;
    }
}

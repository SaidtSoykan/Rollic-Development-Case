using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public List<Level> levels;
    public int currentLevel = 0;
    public static event Action NextLevelStarted;
    public static event Action RestartLevelStarted;
    public static event Action NextLevel;
    public static event Action RestartLevel;
    public static event Action GameStarted;
    public static event Action EndGame;
    public static event Action<int> BallCounted;
    public static event Action GameFinish;
    public static GameManager Instance;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        levels[currentLevel].gameObject.SetActive(true);
    }
    public void OnGameStarted() {
        if(GameStarted != null) {
            GameStarted();
        }
    }
    public void OnGameEnded() {
        if(EndGame != null) {
            EndGame();
        }
    }
    public void OnBallCounted(int balls) {
        if(BallCounted != null) {
            BallCounted(balls);
        }
    }
    public void OnGameFinished() {
        if(GameFinish != null) {
            GameFinish();
        }
    }
    public void OnNextLevel() {
        if(NextLevel != null) {
            NextLevel();
        }
    }
    public void OnRestartLevel() {
        if(RestartLevel != null) {
            RestartLevel();
        }
    }
    public void OnNextLevelStarted() {
        if(NextLevelStarted != null) {
            if(currentLevel < levels.Count) {
                currentLevel++;
                levels[currentLevel].gameObject.SetActive(true);
                levels[currentLevel - 1].gameObject.SetActive(false);
            }
            NextLevelStarted();
        }
    }
    public void OnRestartLevelStarted() {
        if(RestartLevelStarted != null) {
            levels[currentLevel].gameObject.SetActive(true);
            for(int i = 0; i < levels[currentLevel].balls.Count; i++) {
                levels[currentLevel].balls[i].ball.transform.position = levels[currentLevel].balls[i].ballPosition;
                levels[currentLevel].balls[i].ball.SetActive(true);
                levels[currentLevel].balls[i].ball.GetComponent<Rigidbody>().isKinematic = true;
            }
            RestartLevelStarted();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollector : MonoBehaviour
{
    private int ballCounted = 0;
    private bool isFinish = false;
    private bool isCoroutineCalled = false;
    private bool canCount = true;

    private void OnEnable() {
        GameManager.RestartLevelStarted += GameManager_RestartLevelStarted;
        GameManager.NextLevelStarted += GameManager_NextLevelStarted;
    }

    private void GameManager_RestartLevelStarted() {
        StopCoroutine(WaitAndPrint(0));
        ballCounted = 0;
        canCount = true;
        isCoroutineCalled = false;
    }
    private void GameManager_NextLevelStarted() {
        StopCoroutine(WaitAndPrint(0));
        ballCounted = 0;
        canCount = true;
        isCoroutineCalled = false;
    }

    private void OnDisable() {
        GameManager.RestartLevelStarted -= GameManager_RestartLevelStarted;
        GameManager.NextLevelStarted -= GameManager_NextLevelStarted;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collector")) {
            GameManager.Instance.OnGameEnded();
            isFinish = true;
        }
        if(other.gameObject.CompareTag("Ball") && canCount) {
            ballCounted += 1;
            GameManager.Instance.OnBallCounted(ballCounted);
            if(isFinish && !isCoroutineCalled) {
                StartCoroutine(WaitAndPrint(4));
                isCoroutineCalled = true;
            }
        }
    }
    private IEnumerator WaitAndPrint(float endSceneTime){

        yield return new WaitForSeconds(endSceneTime);
        GameManager.Instance.OnGameFinished();
        canCount = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusher : MonoBehaviour
{
    public float target;
    public float destinationZValue;
    public float pusherSpeed;
    private Vector3 pusherFirstPosition;
    private void OnEnable() {
        GameManager.EndGame += GameManager_EndGame;
        GameManager.NextLevelStarted += GameManager_NextLevelStarted;
        GameManager.RestartLevelStarted += GameManager_RestartLevelStarted;
    }

    private void GameManager_RestartLevelStarted() {
        transform.localPosition = Vector3.zero;
        StopCoroutine(Pusher());
    }

    private void GameManager_NextLevelStarted() {
        transform.localPosition = Vector3.zero;
        StopCoroutine(Pusher());
    }

    private void GameManager_EndGame() {
        StartCoroutine(Pusher());
    }
    private void OnDisable() {
        GameManager.GameFinish -= GameManager_EndGame;
        GameManager.NextLevelStarted -= GameManager_NextLevelStarted;
        GameManager.RestartLevelStarted -= GameManager_RestartLevelStarted;
    }
    private void Start() {
        pusherFirstPosition = transform.position;
    }
    IEnumerator Pusher() {
        target = transform.position.z + destinationZValue;
        while(transform.position.z != target) {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,target),pusherSpeed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}

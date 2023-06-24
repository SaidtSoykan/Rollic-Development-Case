using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int requiredBallToNext;
    public Transform collectorStartPosition;
    public List<LevelBallProperties> balls;
    private void Start() {
        for(int i = 0; i < balls.Count; i++) {
            balls[i].ballPosition = balls[i].ball.transform.position;
        }
    }

}
[System.Serializable]
public class LevelBallProperties
{
    public GameObject ball;
    public Vector3 ballPosition;
}
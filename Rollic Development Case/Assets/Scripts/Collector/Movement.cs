using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool canMove = false;
    public Rigidbody rb;
    public float movementSpeed = 10f;
    public float forwardSpeed = 30f;
    private void OnEnable() {
        GameManager.GameStarted += GameManager_GameStarted;
        GameManager.EndGame += GameManager_EndGame;
        GameManager.NextLevelStarted += GameManager_NextLevelStarted;
        GameManager.RestartLevelStarted += GameManager_RestartLevelStarted;
    }

    private void GameManager_RestartLevelStarted() {
        transform.position = GameManager.Instance.levels[GameManager.Instance.currentLevel].collectorStartPosition.position;
        canMove = true;
        rb.isKinematic = false;
    }

    private void GameManager_NextLevelStarted() {
        transform.position = GameManager.Instance.levels[GameManager.Instance.currentLevel].collectorStartPosition.position;
        canMove = true;
        rb.isKinematic = false;
    }

    private void GameManager_EndGame() {
        canMove = false;
        rb.isKinematic = true;
    }

    private void GameManager_GameStarted() {
        canMove = true;
    }

    private void OnDisable() {
        GameManager.GameStarted -= GameManager_GameStarted;
        GameManager.EndGame -= GameManager_EndGame; 
        GameManager.NextLevelStarted -= GameManager_NextLevelStarted;
        GameManager.RestartLevelStarted -= GameManager_RestartLevelStarted;
    }
    private void FixedUpdate() {
        if(canMove) {
            float horizontalMove = transform.position.x;
            float forwardMove = transform.position.z;
            if(Input.touchCount == 1) {
                Touch screenTouch = Input.GetTouch(0);
                if(screenTouch.phase == TouchPhase.Moved) {
                    horizontalMove = transform.position.x + (Mathf.Clamp(screenTouch.deltaPosition.x , -1 , 1) * movementSpeed) * Time.fixedDeltaTime;
                }
            }
            forwardMove = transform.position.z + forwardSpeed * Time.fixedDeltaTime;
            Vector3 movementVector = new Vector3(Mathf.Clamp(horizontalMove , -3 , 3) , transform.position.y , forwardMove);
            transform.position = movementVector;
        }
    }
}
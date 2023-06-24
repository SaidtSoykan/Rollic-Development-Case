using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject endCanvas;
    public GameObject nextCanvas;
    public GameObject restartCanvas;
    public void StartGame() {
        GameManager.Instance.OnGameStarted();
        startCanvas.GetComponent<CanvasGroup>().alpha = 0;
        nextCanvas.GetComponent<CanvasGroup>().alpha = 0;
        restartCanvas.GetComponent<CanvasGroup>().alpha = 0;
        endCanvas.GetComponent<CanvasGroup>().alpha = 0;
        startCanvas.GetComponent<CanvasGroup>().interactable = false;
        nextCanvas.GetComponent<CanvasGroup>().interactable = false;
        restartCanvas.GetComponent<CanvasGroup>().interactable = false;
        startCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        nextCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        restartCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    private void OnEnable() {
        GameManager.EndGame += GameManager_EndGame;
        GameManager.NextLevel += GameManager_NextLevel;
        GameManager.RestartLevel += GameManager_RestartLevel;
    }

    private void GameManager_RestartLevel() {
        restartCanvas.GetComponent<CanvasGroup>().alpha = 1;
        restartCanvas.GetComponent<CanvasGroup>().interactable = true;
        restartCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void GameManager_NextLevel() {
        nextCanvas.GetComponent<CanvasGroup>().alpha = 1;
        nextCanvas.GetComponent<CanvasGroup>().interactable = true;
        nextCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void GameManager_EndGame() {
        endCanvas.GetComponent<CanvasGroup>().alpha = 1;
    }
    private void OnDisable() {
        GameManager.EndGame -= GameManager_EndGame; 
        GameManager.NextLevel -= GameManager_NextLevel; 
        GameManager.RestartLevel -= GameManager_RestartLevel;
    }
    public void NextLevelButton() {
        GameManager.Instance.OnNextLevelStarted();
        nextCanvas.GetComponent<CanvasGroup>().alpha = 0;
        nextCanvas.GetComponent<CanvasGroup>().interactable = false;
        nextCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        endCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void RestartLevelButton() {
        GameManager.Instance.OnRestartLevelStarted();
        restartCanvas.GetComponent<CanvasGroup>().alpha = 0;
        restartCanvas.GetComponent<CanvasGroup>().interactable = false;
        restartCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        endCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }
}

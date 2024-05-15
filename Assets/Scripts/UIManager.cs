using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    GameManager gm;

    private void Start() {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler() {
        gm.StartGame();
        startMenuUI.SetActive(false);
    }

    public void ActivateGameOverUI() {
        gameOverUI.SetActive(true);
    }

    private void OnGUI() {
        ScoreUI.text = gm.PrettyScore();
    }

    
}

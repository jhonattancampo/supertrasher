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
    private GenerateBars generateBars;
    private NewBehaviourScript newBehaviourScript;
    private GeneratePlanter generatePlanter;

    private void Start() {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
        generateBars = FindObjectOfType<GenerateBars>(); // Find the GenerateBars script in the scene
        newBehaviourScript = FindObjectOfType<NewBehaviourScript>(); // Find the NewBehaviourScript in the scene
        generatePlanter = FindObjectOfType<GeneratePlanter>(); // Find the GeneratePlanter script in the scene
    }

    public void PlayButtonHandler() {
        gm.StartGame();
        startMenuUI.SetActive(false);
        generateBars.StartSpawning(); // Start spawning bars when the game starts
        newBehaviourScript.StartSpawning(); // Start spawning dust when the game starts
        generatePlanter.StartSpawning(); // Start spawning planters when the game starts
    }

    public void ActivateGameOverUI() {
        gameOverUI.SetActive(true);
    }

    private void OnGUI() {
        ScoreUI.text = gm.PrettyScore();
    }
}

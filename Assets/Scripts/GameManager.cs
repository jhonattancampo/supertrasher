using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton
        public static GameManager Instance;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
        }
    #endregion

    public float currentScore = 0;
    public bool isPlaying = false;
    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();
    private float gameDuration = 20f;

    private void Update() {
        if (isPlaying) {
            //currentScore += Time.deltaTime;
            //test

        }
    }

    public void StartGame() {
        currentScore = 0; // Reset score to zero at the start of the game
        onPlay.Invoke();
        isPlaying = true;
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer() {
        yield return new WaitForSeconds(gameDuration);
        GameOver();
    }

    public void GameOver() {
        onGameOver.Invoke();
        currentScore = 0; // Ensure score is reset to zero on game over
        isPlaying = false;
    }

    public string PrettyScore () {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public void AdjustScore(int value) {
        currentScore += value;
        if (currentScore < 0) {
            currentScore = 0; // Prevent score from going negative
        }
    }
}

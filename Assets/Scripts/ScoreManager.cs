using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstaculo"))
        {
            score -= 10; // Restar 10 puntos al tocar un obstáculo
            Debug.Log("Puntos Restados: " + score);
        }
        else if (collision.CompareTag("trash"))
        {
            score += 20; // Sumar 20 puntos al tocar un objeto "trash"
            Debug.Log("Puntos Sumados: " + score);
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

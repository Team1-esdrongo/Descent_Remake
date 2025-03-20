using UnityEngine;
using TMPro;

public class Score_System : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        Debug.Log($"Score: {score}");

        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public void KillEnemy(EnemyType enemyType)
    {
        int points = 0;

        switch (enemyType)
        {
            case EnemyType.Normal:
                points = 10;
                break;
            case EnemyType.Boss:
                points = 50;
                break;
            case EnemyType.Elite:
                points = 30;
                break;
            default:
                points = 5;
                break;
        }

        AddPoints(points);
        Debug.Log($"Enemy killed! You earned {points} points.");
    }
}
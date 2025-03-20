using UnityEngine;

public class Enemy_Score : MonoBehaviour
{
    private int points = 10; // Punti assegnati alla morte
    private Score_System scoreSystem;
    public EnemyType enemyType;

    void Start()
    {
        scoreSystem = Object.FindFirstObjectByType<Score_System>();
        if (scoreSystem == null)
        {
            Debug.LogError("ScoreSystem non trovato nella scena!");
        }
    }

    public void Die()
    {
        if (scoreSystem != null)
        {
            scoreSystem.KillEnemy(enemyType);
            Debug.Log($"Nemico sconfitto! Il giocatore guadagna {points} punti.");
        }
        Destroy(gameObject);
    }


}

public enum EnemyType
{
    Normal,
    Elite,
    Boss
}

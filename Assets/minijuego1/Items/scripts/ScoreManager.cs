using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Configuración UI")]
    [SerializeField] private TMP_Text scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
        Debug.Log($"Puntaje actualizado: {currentScore}");
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Puntaje: {currentScore}";
        }
        else
        {
            Debug.LogWarning("Score Text no asignado en el Inspector");
            scoreText = GameObject.FindGameObjectWithTag("puntaje")?.GetComponent<TMP_Text>();
        }
    }
}
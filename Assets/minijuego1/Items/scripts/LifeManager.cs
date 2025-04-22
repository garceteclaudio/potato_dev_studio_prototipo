using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance { get; private set; }

    [Header("Configuración")]
    [SerializeField] private int initialLives = 3;
    [SerializeField] private TMP_Text livesText;

    private int currentLives;

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
        currentLives = initialLives;
        UpdateLivesUI();
    }

    public void LoseLife(int amount)
    {
        currentLives -= amount;
        UpdateLivesUI();
        Debug.Log($"Vidas restantes: {currentLives}");

        if (currentLives <= 0)
        {
            Debug.Log("¡Game Over!");
            // Lógica adicional de game over
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = $"Vidas: {currentLives}";
        }
        else
        {
            Debug.LogWarning("Lives Text no asignado en el Inspector");
            livesText = GameObject.FindGameObjectWithTag("vida")?.GetComponent<TMP_Text>();
        }
    }
}
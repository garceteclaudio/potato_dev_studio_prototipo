using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // <-- Necesario para usar IEnumerator

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public int Vidas { get; private set; } = 5;

    private bool yaGano = false;
    private bool yaPerdio = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SumarP(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);

        if (puntosTotales >= 5 && !yaGano)
        {
            yaGano = true;
            Debug.Log("¡Ganaste!");
            StartCoroutine(CargarEscenaConDelay("Victoria", 0.5f));
            PlayerPrefs.SetInt("nivel_2_desbloqueado", 0);
            PlayerPrefs.SetInt("nivel_3_desbloqueado", 0);
        }
    }

    public void RestarVida()
    {
        Vidas--;
        Debug.Log("Vidas restantes: " + Vidas);

        if (Vidas <= 1)
        {
            Debug.Log("Te queda una vida");
        }

        if (Vidas <= 0 && !yaPerdio)
        {
            yaPerdio = true;
            Debug.Log("¡Juego terminado!");
            StartCoroutine(CargarEscenaConDelay("GameOver", 0.5f));
        }
    }

    private IEnumerator CargarEscenaConDelay(string nombreEscena, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nombreEscena);
    }
}

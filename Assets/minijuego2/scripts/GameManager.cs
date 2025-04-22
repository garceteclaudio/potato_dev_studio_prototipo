using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    public int PuntosTotales { get { return puntosTotales; } } 
  private  int puntosTotales;
    
    //public int vidas = 5;
    public int Vidas { get; private set; } = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("peligro mas de un  Game manager");
        }
    }
    public void SumarP(int puntosASumar)

    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);

        if (puntosTotales >= 20)
        {
            Debug.Log("¡Ganaste!");
          //  SceneManager.LoadScene("Win"); // Asegurate que la escena esté añadida en Build Settings
        }
    }
    
    public void RestarVida()
    {
        Vidas--;
        Debug.Log("Vidas restantes: " + Vidas);

        if (Vidas <= 0)
        {
            Debug.Log("¡Juego terminado!");
            
        }
    }
   
}

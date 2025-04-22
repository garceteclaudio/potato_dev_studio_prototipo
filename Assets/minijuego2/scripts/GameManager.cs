using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    public int PuntosTotales { get { return puntosTotales; } } 
  private  int puntosTotales;
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
    }
}

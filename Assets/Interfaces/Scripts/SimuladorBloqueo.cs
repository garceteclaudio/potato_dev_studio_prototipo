using UnityEngine;
using UnityEngine.SceneManagement;

public class SimuladorBloqueo : MonoBehaviour
{
    public void BloquearNiveles()
    {
        PlayerPrefs.SetInt("nivel_2_desbloqueado", 0);
        PlayerPrefs.SetInt("nivel_3_desbloqueado", 0);
        PlayerPrefs.Save();

        // Ir al mapa de niveles despu�s de desbloquear
        SceneManager.LoadScene("Mapa");
    }
}

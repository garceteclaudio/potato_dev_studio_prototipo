using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorNiveles : MonoBehaviour
{
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}

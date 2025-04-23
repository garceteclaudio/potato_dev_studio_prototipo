using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necesario para componentes UI

public class CambiarEscena : MonoBehaviour
{
    [SerializeField] private string nombreEscena;

    void Start()
    {
        // Obtener el componente Button y asignar el método al evento onClick
        Button boton = GetComponent<Button>();
        if (boton != null)
        {
            boton.onClick.AddListener(CambiarDeEscena);
        }
        else
        {
            Debug.LogError("Este script requiere un componente Button en el GameObject");
        }
    }

    private void CambiarDeEscena()
    {
        if (!string.IsNullOrEmpty(nombreEscena))
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogError("Nombre de escena no asignado en el Inspector");
        }
    }
}
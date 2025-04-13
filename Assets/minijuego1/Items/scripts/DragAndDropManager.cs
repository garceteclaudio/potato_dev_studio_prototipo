using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragAndDropManager : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private Collider2D myCollider;

    [Header("Configuración")]
    [SerializeField] private LayerMask containerLayerMask;

    private void Start()
    {
        mainCamera = Camera.main;
        myCollider = GetComponent<Collider2D>();

        if (mainCamera == null)
        {
            Debug.LogError("No se encontró la cámara principal.", this);
        }
    }

    private void OnMouseDown()
    {
        if (!myCollider.enabled) return;

        isDragging = true;
        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        myCollider.enabled = false;
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        if (!isDragging) return;

        isDragging = false;
        myCollider.enabled = true;

        CheckDropOnContainer();
    }

    private void CheckDropOnContainer()
    {
        Vector2 rayOrigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 0.1f, containerLayerMask);

        if (hit.collider != null && hit.collider.CompareTag("contenedor-organico"))
        {
            HandleContainerDrop(hit.collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void HandleContainerDrop(GameObject container)
    {
        if (gameObject.CompareTag("elemento-comida"))
        {
            ScoreManager.Instance?.AddScore(1);
            SwitchContainers();
        }
        else if (gameObject.CompareTag("item"))
        {
            LifeManager.Instance?.LoseLife(1);
        }
    }

    private void SwitchContainers()
    {
        // Buscar y activar el contenedor de vidrio
        GameObject glassContainer = GameObject.FindGameObjectWithTag("contenedor-vidrio");
        if (glassContainer != null)
        {
            Debug.Log("Se activara contendor vidrio");
            glassContainer.SetActive(true);
            glassContainer.GetComponent<Collider2D>().enabled = true;
        }

        // Buscar y desactivar el contenedor orgánico
        GameObject organicContainer = GameObject.FindGameObjectWithTag("contenedor-organico");
        if (organicContainer != null)
        {
            organicContainer.SetActive(false);
            organicContainer.GetComponent<Collider2D>().enabled = false;
        }


    }
}
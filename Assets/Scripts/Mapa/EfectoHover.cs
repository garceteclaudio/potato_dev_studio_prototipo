using UnityEngine;
using UnityEngine.EventSystems;

public class EfectoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imagenHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imagenHover != null)
            imagenHover.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imagenHover != null)
            imagenHover.SetActive(false);
    }
}

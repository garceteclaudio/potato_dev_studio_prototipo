using UnityEngine;
using UnityEngine.EventSystems;

public class EfectoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imagenHover;
    public AudioSource audioSource;
    public AudioClip hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imagenHover != null)
            imagenHover.SetActive(true);

        if (audioSource != null && hoverSound != null)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imagenHover != null)
            imagenHover.SetActive(false);
    }
}

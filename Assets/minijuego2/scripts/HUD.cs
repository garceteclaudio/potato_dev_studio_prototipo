using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;

    void Update()
    {
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }
}

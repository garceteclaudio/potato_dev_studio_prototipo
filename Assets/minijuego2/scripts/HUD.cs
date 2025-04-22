using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI vidas;


    void Update()
    {
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
        vidas.text = "Vidas: " + GameManager.Instance.Vidas.ToString();
    }
}

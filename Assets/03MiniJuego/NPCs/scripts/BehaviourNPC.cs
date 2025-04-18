using UnityEngine;
using System.Collections;
using TMPro;
public class BehaviourNPC : MonoBehaviour
{
    private bool isPlayer;
    private bool didDialogueStart;
    private int indexLine;

    [SerializeField]private GameObject aviso;
    [SerializeField, TextArea(6, 4)] private string[] lineaTexto;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    // Update is called once per frame
    void Update()
    {
        if (isPlayer&& Input.GetKeyUp(KeyCode.Space))
        {
            if (!didDialogueStart)
            {
                EmpezarDialogo();
            }
            else if (textoDialogo.text == lineaTexto[indexLine])
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                textoDialogo.text= lineaTexto[indexLine];
            }
        }
    }

    public void EmpezarDialogo()
    {
        didDialogueStart = true;
        panelDialogo.SetActive(true);
        aviso.SetActive(false);
        indexLine = 0;
        StartCoroutine(MostrarLineas());
    }
    private IEnumerator MostrarLineas()
    {
        textoDialogo.text=string.Empty;
        foreach(char c in lineaTexto[indexLine])
        {
            textoDialogo.text+=c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void SiguienteLinea()
    {
        indexLine++;
        if(indexLine< lineaTexto.Length)
        {
            StartCoroutine(MostrarLineas());
        }
        else
        {
            didDialogueStart=false;
            panelDialogo.SetActive(false);
            aviso.SetActive(true);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayer = true;
        aviso.SetActive(true);
        Debug.Log("ya estoy");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;
        Debug.Log("me fui");
        aviso.SetActive(false);
    }
}

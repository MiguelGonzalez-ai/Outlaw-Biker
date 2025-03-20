using System.Diagnostics.Contracts;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject textoGanador;
    public AudioClip coinSound;
    public controladorJugador ganador;
    public GameObject finalBorde;
    Collider2D colision;

    void Start()
    {
        colision = finalBorde.GetComponent<Collider2D>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            ganador.ganador = true;
            textoGanador.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            ganador.ganador = false;
            colision.isTrigger = false;
        }
    }
}

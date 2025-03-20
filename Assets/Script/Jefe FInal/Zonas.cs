using System.Diagnostics.Contracts;
using UnityEngine;

public class Zonas : MonoBehaviour
{
    public int zona;
    public JefeFinal activador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            activador.zona = zona;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            activador.zona = 0;
        }
    }
}

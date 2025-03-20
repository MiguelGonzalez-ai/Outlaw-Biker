using UnityEngine;

public class CajaProyectiles : MonoBehaviour
{
    GameObject jugador;
    controladorJugador contador;

    void Start()
    {
        jugador = FindFirstObjectByType<controladorJugador>().gameObject;
        contador = jugador.GetComponent<controladorJugador>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            contador.proyectiles += 5;
            Destroy(gameObject);

        }
        
    }

 
}

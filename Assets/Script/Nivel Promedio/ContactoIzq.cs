using UnityEngine;

public class ContactoIzq : MonoBehaviour
{
    public Enemigo contacto;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            contacto.contactoIzq = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            contacto.contactoIzq = false;
        }
    }
}

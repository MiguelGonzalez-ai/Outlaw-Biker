using UnityEngine;

public class ContactoDer : MonoBehaviour
{
    public Enemigo contacto;

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
            contacto.contactoDer = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            contacto.contactoDer = false;
        }
    }
}

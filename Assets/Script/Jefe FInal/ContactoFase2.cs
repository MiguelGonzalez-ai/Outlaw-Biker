using UnityEngine;

public class ContactoFase2 : MonoBehaviour
{
    public MovimientoCañon contacto;
    public JefeFinal contacto2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contacto.contactoCañon = true;
            contacto2.contacto = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contacto.contactoCañon = false;
            contacto2.contacto = false;
        }
    }
}

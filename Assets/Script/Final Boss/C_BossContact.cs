using System.Diagnostics.Contracts;
using UnityEngine;

public class C_BossContact : MonoBehaviour
{
    GameObject Boss;
    C_BossPhases ConfirmContact;
    void Start()
    {
        Boss = FindFirstObjectByType<C_BossPhases>().gameObject;
        ConfirmContact = Boss.GetComponent<C_BossPhases>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.LogWarning("Hay Contacto con el jugador");
            ConfirmContact.SetContact(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.LogWarning("No hay contacto con el jugador");
            ConfirmContact.SetContact(false);
        }
    }
}

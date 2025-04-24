using System.Diagnostics.Contracts;
using UnityEngine;

public class C_BossContact : MonoBehaviour
{
    private GameObject Boss;
    private C_BossPhases ConfirmContact;
    private GameObject Canon;
    private C_BossCanon ConfirmCanon;
    void Start()
    {
        Boss = FindFirstObjectByType<C_BossPhases>().gameObject;
        Canon = FindFirstObjectByType<C_BossCanon>().gameObject;
        if(Boss != null) ConfirmContact = Boss.GetComponent<C_BossPhases>();
        if (Canon != null) ConfirmCanon = Canon.GetComponent<C_BossCanon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.LogWarning("Hay Contacto con el jugador");
            ConfirmContact.SetContact(true);
            ConfirmCanon.SetCanonContact(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.LogWarning("No hay contacto con el jugador");
            ConfirmContact.SetContact(false);
            ConfirmCanon.SetCanonContact(false);
        }
    }
}

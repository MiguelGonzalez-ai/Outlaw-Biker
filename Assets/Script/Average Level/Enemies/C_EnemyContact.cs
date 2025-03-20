using System.Diagnostics.Contracts;
using UnityEngine;

public class C_EnemyContact : MonoBehaviour
{
    C_EnemyController Contact;
    [SerializeField] GameObject Enemy; //Enemigo instanciado en el inspector
    void Start()
    {
        if(Enemy != null)
        {
           Contact  = Enemy.GetComponent<C_EnemyController>();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Contact.Contact = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Contact.Contact = false;
        }
    }
}

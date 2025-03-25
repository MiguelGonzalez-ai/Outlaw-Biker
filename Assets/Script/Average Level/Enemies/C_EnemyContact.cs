using System.Diagnostics.Contracts;
using UnityEngine;

public class C_EnemyContact : MonoBehaviour
{
    private C_EnemyController Contact;
    [SerializeField] private GameObject Enemy; //Enemigo instanciado en el inspector
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
            Contact.SetEnemyContact(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Contact.SetEnemyContact(false);
        }
    }
}

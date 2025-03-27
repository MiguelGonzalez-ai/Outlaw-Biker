using UnityEngine;

public class C_EnemyBehind : MonoBehaviour
{
    private C_EnemyController Contact;
    [SerializeField] private GameObject Enemy; //Enemigo instanciado en el inspector
    void Start()
    {
        if (Enemy != null)
        {
            Contact = Enemy.GetComponent<C_EnemyController>();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Contact.SetEnemysBehind(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Contact.SetEnemysBehind(false);
        }
    }
}

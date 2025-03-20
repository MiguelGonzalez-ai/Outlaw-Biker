using UnityEngine;

public class C_EnemyWeakness : MonoBehaviour
{
    [SerializeField] float SpeedBounce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.GetContact(0).normal.y < -0.9f)
            {
                collision.gameObject.GetComponent<C_PlayerController>().Bounce(SpeedBounce);
                Destroy(gameObject);
            }   
        }
    }
}

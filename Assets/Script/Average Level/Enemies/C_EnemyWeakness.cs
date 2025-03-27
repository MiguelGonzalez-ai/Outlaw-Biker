using System.Diagnostics;
using UnityEngine;

public class C_EnemyWeakness : MonoBehaviour
{
    [SerializeField] private float SpeedBounce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (collision.GetContact(0).normal.y < -0.9f)
        {
            collision.gameObject.GetComponent<C_PlayerController>().Bounce(SpeedBounce);
            Destroy(gameObject);
        }
        else if (collision.GetContact(0).normal.x < -0.9f || collision.GetContact(0).normal.x > 0.9f)
        {
            C_PlayerLife GiveDamage = collision.gameObject.GetComponent<C_PlayerLife>();
            GiveDamage.TakingDamage(0.2f);
        }
    }
}

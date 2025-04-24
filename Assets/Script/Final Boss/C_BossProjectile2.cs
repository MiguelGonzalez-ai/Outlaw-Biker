using UnityEngine;

public class C_BossProjectile2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject Player;
    private C_PlayerLife PlayersLife;
    [SerializeField] float SpeedProjectile;
    [SerializeField] float Damage;
    void Start()
    {
        Player = FindFirstObjectByType<C_PlayerLife>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        Launching();

    }

    private void Launching()
    {
        if (Player != null)
        {
            PlayersLife = Player.GetComponent<C_PlayerLife>();
            rb.linearVelocity = transform.right * SpeedProjectile;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayersLife.TakingDamage(Damage);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }
    }

}

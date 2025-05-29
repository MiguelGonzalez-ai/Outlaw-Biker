using System.Collections;
using UnityEngine;

public class C_PlayerProjectile : C_Projectile
{
    private C_BossLife BossLife => C_Managment.Instance.BossLife;
    [SerializeField] private float Damage;
    protected override void Start()
    {
        Direction();
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            BossLife.TakingDamage(Damage);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }
    }
}

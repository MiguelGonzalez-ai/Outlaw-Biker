using System.Collections;
using UnityEngine;

public class C_PlayerProjectile : C_Projectile
{
    private GameObject Boss;
    private C_BossLife BossLife;
    [SerializeField] private float Damage;
    void Start()
    {
        Boss = FindFirstObjectByType<C_BossLife>().gameObject;
        if(Boss != null)
        {
            BossLife = Boss.GetComponent<C_BossLife>();
        }
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch(WaitTime));
    }
    
    protected override IEnumerator Launch(float WaitTime)
    {
        yield return base.Launch(WaitTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            BossLife.TakingDamage(Damage);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }
}

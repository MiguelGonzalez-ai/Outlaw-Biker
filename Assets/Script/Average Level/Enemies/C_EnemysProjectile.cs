using System.Collections;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

/*
* 
* --------Explicacion Clase--------
* Lanza el projectile segun el lado y su velocidad
*
*/
public class C_EnemysProjectile : C_Projectile
{
    private GameObject Player;
    private C_PlayerLife Life;
    [SerializeField] private float Damage;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        Player = FindFirstObjectByType<C_PlayerLife>().gameObject;
        if(Player != null)
        {
            Life = Player.GetComponent<C_PlayerLife>();
            StartCoroutine(Launch(WaitTime));
        }
    }

    /*
     * Corrutina que lanza el proyectil y lo eliminar despues del tiempo asignado en WaiTime
     */
    protected override IEnumerator Launch(float WaitTime)
    {
        yield return base.Launch(WaitTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Life.TakingDamage(Damage);
            Destroy(gameObject);
        }
    }


}

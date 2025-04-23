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
    private C_PlayerLife Life => C_Managment.Instance.PlayerLife;
    [SerializeField] private float Damage;
    [SerializeField] private float RotationSpeed;
    

    private void FixedUpdate()
    {
        transform.Rotate(-Vector3.forward, RotationSpeed * Side * Time.deltaTime);
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

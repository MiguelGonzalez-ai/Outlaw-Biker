using UnityEngine;

public class C_Box : C_Item
{
    private C_PlayerLaunchProjectiles Counter => C_Managment.Instance.PlayerLaunchProjectiles;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Counter == null) return;
            Counter.IncreasePlayersCounterProjectiles(5);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class C_Collectible : C_Item
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            C_Managment.Instance.IncreaseCollectiblesCounter();
            Destroy(gameObject);
        }
    }
}

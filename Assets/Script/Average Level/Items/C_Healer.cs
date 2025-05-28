using UnityEngine;

public class C_Healer : C_Item
{
    private C_PlayerLife Heal => C_Managment.Instance.PlayerLife;
    [SerializeField] private float AmountHealing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Heal == null) return;
            Heal.Healing(AmountHealing);
            Destroy(gameObject);
        }
    }
}

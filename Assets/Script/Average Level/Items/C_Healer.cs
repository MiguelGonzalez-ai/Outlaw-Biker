using UnityEngine;

public class C_Healer : C_Item
{
    GameObject Player;
    C_PlayerLife Heal;
    [SerializeField] float AmountHealing;
    void Start()
    {
        Player = FindFirstObjectByType<C_PlayerLife>().gameObject;
        if(Player != null)
        {
            Heal = Player.GetComponent<C_PlayerLife>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        OffsetItem();
    }

    protected override void OffsetItem()
    {
        base.OffsetItem();
    }

    protected override float OffsetSin()
    {
        return base.OffsetSin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Heal.Healing(AmountHealing);
            Destroy(gameObject);
        }
    }
}

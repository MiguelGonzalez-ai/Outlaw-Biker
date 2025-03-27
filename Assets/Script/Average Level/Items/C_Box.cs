using UnityEngine;

public class C_Box : C_Item
{
    private GameObject Player;
    private C_PlayerLaunchProjectiles Counter;
    void Start()
    {
        Player = FindFirstObjectByType<C_PlayerLaunchProjectiles>().gameObject;
        if(Player != null)
        {
            Counter = Player.GetComponent<C_PlayerLaunchProjectiles>();
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
            Counter.SetPlayersCounterProjectiles(5);
            Destroy(gameObject);
        }
    }
}

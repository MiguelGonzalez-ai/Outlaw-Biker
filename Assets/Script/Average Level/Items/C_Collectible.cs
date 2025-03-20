using UnityEngine;

public class C_Collectible : C_Item
{

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
            AccessManagement.CollectiblesCounter++;
            Destroy(gameObject);
        }
    }
}

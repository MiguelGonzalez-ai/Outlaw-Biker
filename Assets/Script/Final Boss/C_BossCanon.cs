using UnityEngine;

public class C_BossCanon : MonoBehaviour
{
    private C_BossLife BossLife;
    private bool bContactCanon;
    private Vector2 PlayerDirection;
    [SerializeField] private Transform PlayerPosition;

    /*
     * Setter
     */
    public void SetCanonContact(bool bContact) { bContactCanon = bContact; }

    void Start()
    {
        BossLife = GetComponentInParent<C_BossLife>();
        bContactCanon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossLife.GetBossLife() <= 0.5 && bContactCanon) CanonRotation();
    }

    private void CanonRotation()
    {
        Debug.Log("Rotando ");
        if (PlayerDirection == null) return;
        PlayerDirection = ((Vector2)PlayerPosition.position - (Vector2)transform.position).normalized;
        transform.right = PlayerDirection;
    }
}

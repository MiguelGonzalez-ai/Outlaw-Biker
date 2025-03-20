using System.Collections;
using UnityEngine;

public class C_Projectile : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float WaitTime;
    [SerializeField] protected float SpeedX;
    [SerializeField] protected float SpeedY;
    public int Side;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch(WaitTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual IEnumerator Launch(float WaitTime)
    {

        Vector2 velocity = new Vector2(Side * SpeedX, SpeedY);
        rb.linearVelocity = velocity;

        yield return new WaitForSeconds(WaitTime);
        Destroy(gameObject);
    }
}

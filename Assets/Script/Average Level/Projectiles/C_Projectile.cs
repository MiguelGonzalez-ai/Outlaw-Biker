using System.Collections;
using UnityEngine;

public class C_Projectile : MonoBehaviour
{
    protected int Side;
    protected Rigidbody2D rb;
    [SerializeField] protected int DirectionRotation;
    [SerializeField] protected float WaitTime;
    [SerializeField] protected float SpeedX;
    [SerializeField] protected float SpeedY;
    [SerializeField] protected float RotationSpeed;

    /*
     * Getters y Setters
     */
    public void SetProjectileSide(int SideEnemy) { Side = SideEnemy; }

    protected void Direction()
    {
        int Aux = Random.Range(1, 10);
        DirectionRotation = (Aux >= 6) ? 1 : -1;
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch(WaitTime));
    }

    protected virtual void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, RotationSpeed * DirectionRotation * Time.deltaTime);
    }

    protected IEnumerator Launch(float WaitTime)
    {

        Vector2 velocity = new Vector2(Side * SpeedX, SpeedY);
        rb.linearVelocity = velocity;

        yield return new WaitForSeconds(WaitTime);
        Destroy(gameObject);
    }
}

using UnityEngine;

public class C_BossMovement : MonoBehaviour
{
    private Vector2 NextPosition;
    private Vector2 PositionA;
    private Collider2D Colision;
    private C_BossPhases Counter;
    [SerializeField] private Transform PositionB;
    [SerializeField] private float SpeedTruck;
    void Start()
    {
        Colision = GetComponent<Collider2D>();
        Counter = GetComponent<C_BossPhases>();
        NextPosition = (Vector2)PositionB.position;
        PositionA = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Counter.GetCounterProjectiles() >= 20)
        {
            MoveTruck();
            if(Vector2.Distance(transform.position, NextPosition) < 0.1f)
            {
                ChangeDirection();
            }
        }
    }

    private void MoveTruck()
    {
        transform.position = Vector2.MoveTowards(transform.position, NextPosition, SpeedTruck * Time.deltaTime);
        Colision.isTrigger = true;
    }

    private void ChangeDirection()
    {
        //Establece la siguiente posicion, si la posicion de camion es cercana a la posicion A, se establece a la posicion B
        //Si no, a la posicion A
        NextPosition = (Vector2.Distance(transform.position, PositionA) < 0.1f) ? PositionB.position : PositionA;
        //Restablece el contador
        Counter.SetCounterProjectiles(0);
        C_Managment.Instance.BossManager.SetCanSpawn(false);

        //Girar el camion 180 grados alrededor del eje y
        transform.Rotate(transform.position.x, transform.position.y + 180, 0);
        //Activar la colision del camion
        Colision.isTrigger = false;
    }
}

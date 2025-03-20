using UnityEngine;

public class C_BossProjectile1 : MonoBehaviour
{
    GameObject Target;
    Transform TargetPosition; //Transformada del jugadaor
    C_PlayerLife PlayerLife; //Permite acceder a la vida del personaje
    Vector2 PositionA; //Posicion de lanzamiento
    Vector2 PositionB; //Posicion del jugador con Vector2
    float RunningTimeFrame;
    float Time;
    [SerializeField] float Duration;
    [SerializeField] float Damage;
    public AnimationCurve Trajectory;

    void Start()
    {
        Target = FindFirstObjectByType<C_PlayerController>().gameObject;
        if (Target != null)
        {
            TargetPosition = Target.GetComponent<Transform>();
            PlayerLife = Target.GetComponent<C_PlayerLife>();
            PositionA = (Vector2)transform.position;
            PositionB = (Vector2)TargetPosition.position;
        }
        RunningTimeFrame = 0;

    }

    // Update is called once per frame
    void Update()
    {
        CalculatingTime();
        if(Time <= Duration)
        {
            Launching();
        }
    }

    private void CalculatingTime()
    {
        RunningTimeFrame += UnityEngine.Time.deltaTime;
        Time = RunningTimeFrame / Duration;
    }

    private void Launching()
    {
        Vector2 Position = Vector2.Lerp(PositionA, PositionB, Time);
        Position.y = Trajectory.Evaluate(Time);
        transform.position = Position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLife.TakingDamage(Damage);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }
}

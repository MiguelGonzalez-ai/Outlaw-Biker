using UnityEngine;

public class C_BossProjectile1 : C_Projectile
{
    private GameObject Target => C_Managment.Instance.Player;
    private Transform TargetPosition => Target.transform; //Transformada del jugadaor
    private C_PlayerLife PlayerLife => C_Managment.Instance.PlayerLife; //Permite acceder a la vida del personaje
    private Vector2 PositionA; //Posicion de lanzamiento
    private Vector2 PositionB; //Posicion del jugador con Vector2
    private float RunningTimeFrame;
    private float Time;
    [SerializeField] private float Duration;
    [SerializeField] private float Damage;
    public AnimationCurve Trajectory;

    protected override void Start()
    {
        Direction();
        if (Target != null)
        {
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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
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

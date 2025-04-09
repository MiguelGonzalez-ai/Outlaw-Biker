using UnityEngine;

public class C_BossPhases : MonoBehaviour
{
    enum EBossPhases
    {
        BP_PhaseChange1,
        BP_PhaseChange2,
        BP_Phase1,
        BP_Phase2
    }
    
    private C_BossLife BossLife;
    private bool bContact;
    private int CounterProjectiles;
    [SerializeField] private EBossPhases BossPhase;
    [SerializeField] private Transform LaunchPositionPhase1;
    [SerializeField] private Transform LaunchPositionPhase2;
    [SerializeField] private Transform Canon;
    [SerializeField] private GameObject ProjectilePhase1;
    [SerializeField] private GameObject ProjectilePhase2;
    [SerializeField] private AnimationCurve TrajectoryPhase1;
    

    /*
     * Getters y setters
     */
    public int GetCounterProjectiles() { return CounterProjectiles; }
    public void SetCounterProjectiles(int Amount) { CounterProjectiles = Amount;  }
    public void SetContact(bool ForwardContact) { bContact = ForwardContact; }
    

    private void Start()
    {
        bContact = false;
        CounterProjectiles = 0;
        BossLife = GetComponent<C_BossLife>();
    }
    void Update()
    {
        ChangingBossPhase();
        ActivatingBossPhase();
    }

    //Cambia la fase del jefe dependiendo de la base
    private void ChangingBossPhase()
    {
        if(BossPhase == EBossPhases.BP_PhaseChange1 && BossLife.GetBossLife() <= 0.5)
        {
            BossPhase = EBossPhases.BP_Phase2;
        }
        else if(BossLife.GetBossLife() < 0.05f)
        {
            Destroy(gameObject);
        }
    }

    //Activa la fase del jefe dependiendo del Enum
    private void ActivatingBossPhase()
    {
        switch (BossPhase)
        {
            case EBossPhases.BP_Phase1:
                BossPhase = EBossPhases.BP_PhaseChange1;
                InvokeRepeating("Phase1", 0f, 1f);
                break;
            case EBossPhases.BP_Phase2:
                CancelInvoke("Phase1");
                InvokeRepeating("Phase2", 0f, 2f);
                BossPhase = EBossPhases.BP_PhaseChange2;
                break;

        }
    }

    private void Phase1()
    {
        if(bContact && ProjectilePhase1 != null)
        {
            Debug.LogWarning("Disparando Fase 1");
            GameObject Projectile = Instantiate(ProjectilePhase1, LaunchPositionPhase1.position, Quaternion.identity);
            C_BossProjectile1 AuxProjectile = Projectile.GetComponent<C_BossProjectile1>();
            AuxProjectile.Trajectory = TrajectoryPhase1;
            CounterProjectiles++;
            
        }
    }

    private void Phase2()
    {
        if(bContact && ProjectilePhase2 != null && Canon != null)
        {
            Debug.LogWarning("Disparando Fase 2");
            Instantiate(ProjectilePhase2, LaunchPositionPhase2.position, Canon.transform.rotation);
            CounterProjectiles++;
        }
    }

    

    
}

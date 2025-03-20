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
    C_BossLife BossLife;

    bool Contact;
    [SerializeField] EBossPhases BossPhase;
    [SerializeField] Transform LaunchPositionPhase1;
    [SerializeField] Transform LaunchPositionPhase2;
    [SerializeField] GameObject ProjectilePhase1;
    [SerializeField] GameObject ProjectilePhase2;
    [SerializeField] AnimationCurve TrajectoryPhase1;
    public int CounterProjectiles;
    public void SetContact(bool ForwardContact) { Contact = ForwardContact; }
    

    private void Start()
    {
        Contact = false;
        CounterProjectiles = 0;
        BossLife = GetComponent<C_BossLife>();
    }
    void Update()
    {
        ChangingBossPhase();
        ActivatingBossPhase();
    }

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
                BossPhase = EBossPhases.BP_PhaseChange2;
                break;

        }
    }

    private void Phase1()
    {
        if(Contact)
        {
            Debug.LogWarning("Disparando Fase 1");
            GameObject Projectile = Instantiate(ProjectilePhase1, LaunchPositionPhase1.position, Quaternion.identity);
            C_BossProjectile1 AuxProjectile = Projectile.GetComponent<C_BossProjectile1>();
            AuxProjectile.Trajectory = TrajectoryPhase1;
            CounterProjectiles++;
            
        }
    }

    

    
}

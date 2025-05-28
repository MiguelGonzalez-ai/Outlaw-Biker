using UnityEngine;



public class C_EnemyController : MonoBehaviour
{
    private enum EEnemyState
    {
        EES_Idle,
        EES_Turning,
        EES_Attacking
    }
    private enum EEnemyForward
    {
        EEF_Right,
        EEF_Left
    }
    private int Side;
    [SerializeField] private bool bContact;
    [SerializeField] private bool bBehind;
    [SerializeField] private EEnemyState EnemyState;
    [SerializeField] private EEnemyForward EnemySide;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform LaunchPosition;

    /*
     * Getters y setters
     */
    public void SetEnemysBehind(bool BehindEnemy) { bBehind = BehindEnemy; }
    public void SetEnemyContact(bool ContactEnemy) { bContact = ContactEnemy; }


    void Awake()
    {
        bContact = false;
        bBehind = false;
        EnemyState = EEnemyState.EES_Idle;
        InitialSide();
    }

    // Update is called once per frame
    void Update()
    {
        Attacking();
        Turning();
    }

    private void Attacking()
    {
        if (bContact && EnemyState == EEnemyState.EES_Idle) //Si el enemigo tiene contacto visual y se encuentra inactivo, ataca
        {
            EnemyState = EnemyState = EEnemyState.EES_Attacking;
            InvokeRepeating("SpawnProjectile", 2f, 2f);
        }
        else if (!bContact && EnemyState == EEnemyState.EES_Attacking) //Si el enemigo ya no tiene contacto visual y esta atacando, dejara de hacerlo
        {
            EnemyState = EEnemyState.EES_Idle;
            CancelInvoke("SpawnProjectile");
        }
    }

    private void Turning()
    {
        if (bBehind && EnemyState == EEnemyState.EES_Idle) //Si el jugador esta atras y el enemigo se encuentra inactivo, se volteara
        {
            EnemyState = EEnemyState.EES_Turning;
            ChangeSide();
        }
        else if (!bBehind && EnemyState == EEnemyState.EES_Turning) //Si el jugador ya no se encuentra atras y el jugador volteo, quedara inactivo
        {
            EnemyState = EEnemyState.EES_Idle;
        }
    }

    private void InitialSide()
    {
        if(EnemySide == EEnemyForward.EEF_Right)
        {
            Side = 1;
            transform.localScale = new Vector3(Side, 1, 1);
        }
        else if(EnemySide == EEnemyForward.EEF_Left)
        {
            Side = -1;
            transform.localScale = new Vector3(Side, 1, 1);
        }
    }

    private void ChangeSide()
    {
        Side *= -1;
        transform.localScale = new Vector3(Side, 1, 1);
    }

    private void SpawnProjectile()
    {
        GameObject Projectile2 = Instantiate(Projectile, LaunchPosition.position, Quaternion.identity);
        C_EnemysProjectile SideProjectile2 = Projectile2.GetComponent<C_EnemysProjectile>();
        SideProjectile2.SetProjectileSide(Side);
    }
}

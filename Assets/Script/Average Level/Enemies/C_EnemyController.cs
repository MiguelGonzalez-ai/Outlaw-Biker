using UnityEngine;

public class C_EnemyController : MonoBehaviour
{
    private enum EEnemyState
    {
        EES_Idle,
        EES_Turning,
        EES_Attacking
    }
    private int Side;
    [SerializeField] private bool Contact;
    [SerializeField] private bool Behind;
    [SerializeField] private EEnemyState EnemyState;
    [SerializeField] GameObject Projectile;
    [SerializeField] Transform LaunchPosition;

    /*
     * Getters y setters
     */
    public void SetEnemysBehind(bool BehindEnemy) { Behind = BehindEnemy; }
    public void SetEnemyContact(bool ContactEnemy) { Contact = ContactEnemy; }


    void Start()
    {
        Contact = false;
        Behind = false;
        Side = -1;
        EnemyState = EEnemyState.EES_Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(Contact && EnemyState == EEnemyState.EES_Idle) //Si el enemigo tiene contacto visual y se encuentra inactivo, ataca
        {
            EnemyState = EnemyState = EEnemyState.EES_Attacking;
            InvokeRepeating("SpawnProjectile", 2f, 2f);
        }
        else if(!Contact && EnemyState == EEnemyState.EES_Attacking) //Si el enemigo ya no tiene contacto visual y esta atacando, dejara de hacerlo
        {
            EnemyState = EEnemyState.EES_Idle;
            CancelInvoke("SpawnProjectile");
        }
        if(Behind && EnemyState == EEnemyState.EES_Idle) //Si el jugador esta atras y el enemigo se encuentra inactivo, se volteara
        {
            EnemyState = EEnemyState.EES_Turning; 
            ChangeSide();
        }
        else if(!Behind && EnemyState == EEnemyState.EES_Turning) //Si el jugador ya no se encuentra atras y el jugador volteo, quedara inactivo
        {
            EnemyState = EEnemyState.EES_Idle;
        }
    }

    private void ChangeSide()
    {
        transform.localScale = new Vector3(Side, 1, 1);
        Side *= -1;
    }

    private void SpawnProjectile()
    {
        GameObject Projectile2 = Instantiate(Projectile, LaunchPosition.position, Quaternion.identity);
        C_EnemysProjectile SideProjectile2 = Projectile2.GetComponent<C_EnemysProjectile>();
        SideProjectile2.SetProjectileSide(Side);
    }
}

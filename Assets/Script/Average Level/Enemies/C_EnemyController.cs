using UnityEngine;

public class C_EnemyController : MonoBehaviour
{
    int Side;
    int Aux; //Permite que solo entre al condicional una sola vez
    [SerializeField] GameObject Projectile;
    [SerializeField] Transform LaunchPosition;
    public bool Contact;
    public bool Behind;

    void Start()
    {
        Contact = false;
        Behind = false;
        Side = -1;
        Aux = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Contact && Aux == 0) //Si el enemigo tiene contacto visual con el jugador (True), empieza a lanzar projectiles despues de 2 seg, cada 2 seg
        {
            Aux = 1;
            InvokeRepeating("SpawnProjectile", 2f, 2f);
        }
        else if(!Contact && Aux == 1) //Si el enemigo ya no tiene contacto visual (false), dejara de lanzar
        {
            Aux = 0;
            CancelInvoke("SpawnProjectile");
        }
        if(Behind && Aux == 0) //Si el enemigo sabe que el jugador esta atras de el, se volteara
        {
            Aux = 2; 
            ChangeSide();
        }
        else if(!Behind && Aux == 2) //Restablecera al enemigo si volteo, para que pueda lanzar
        {
            Aux = 0;
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
        SideProjectile2.Side = Side;
    }
}

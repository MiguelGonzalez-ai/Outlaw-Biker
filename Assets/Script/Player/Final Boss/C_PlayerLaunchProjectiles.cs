using UnityEngine;

public class C_PlayerLaunchProjectiles : MonoBehaviour
{
    private C_PlayerController SidePlayer;
    private int CounterProjectiles;
    [SerializeField] private Transform LaunchPosition;
    [SerializeField] private GameObject PlayerProjectiles;

    /*
     * Public
     */
    public void IncreasePlayersCounterProjectiles(int Amount) { CounterProjectiles = Mathf.Clamp(CounterProjectiles + Amount, 0, 10); }

    void Start()
    {
        CounterProjectiles = 0;
        if(GetComponent<C_PlayerController>() != null)
        {
            SidePlayer = GetComponent<C_PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterProjectiles > 0 && Input.GetKeyDown(KeyCode.R))
        {
            LaunchingProjectiles();
        }
    }

    private void LaunchingProjectiles()
    {
        CounterProjectiles = Mathf.Clamp(CounterProjectiles - 1, 0, 20);
        GameObject PlayerProjectiles2 = Instantiate(PlayerProjectiles, LaunchPosition.position, Quaternion.identity);
        C_PlayerProjectile Access = PlayerProjectiles2.GetComponent<C_PlayerProjectile>();
        Access.SetProjectileSide(SidePlayer.GetPlayerSide());
    }
}

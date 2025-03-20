using UnityEngine;

public class C_PlayerLaunchProjectiles : MonoBehaviour
{
    C_PlayerController SidePlayer;
    [SerializeField] Transform LaunchPosition;
    [SerializeField] GameObject PlayerProjectiles;
    public int CounterProjectiles;

    void Start()
    {
        CounterProjectiles = 0;
        SidePlayer = GetComponent<C_PlayerController>();
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
        Access.Side = SidePlayer.Side;
    }
}

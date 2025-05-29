using UnityEngine;

public class C_BossManager : MonoBehaviour
{
    private ELevel CurrentLevel => C_Managment.Instance.GetCurrentLevel();
    private C_PlayerLife PlayerLife => C_Managment.Instance.PlayerLife;
    private C_BossLife BossLife => C_Managment.Instance.BossLife;
    private C_BossPhases BossPhases => C_Managment.Instance.BossPhases;
    [SerializeReference]private bool bCanSpawn = true;

    [SerializeField] private GameObject BoxProjectiles;
    //Public
    public void ChangeSceneBoss()
    {
        StartCoroutine(C_Managment.Instance.ChangeScene(5));
    }

    //setter
    public void SetCanSpawn(bool Can) { bCanSpawn = Can; }
    
    void Update()
    {
        ManageItems();
        ManageBossLife();
    }

    private void ManageItems()
    {
        if (BossPhases.GetCounterProjectiles() == 20 && bCanSpawn == true)
        {
            Debug.Log("Spawneando Proyectiles");
            bCanSpawn = false;
            SpawnPlayerProjectiles();
        }
    }

    private void SpawnPlayerProjectiles()
    {
        if(BoxProjectiles != null)
        {
            float RandomX = Random.Range(-10.78f, 11.49f);
            Vector3 RandomSpawnPoint = new(RandomX, -2.69f, 0);
            Instantiate(BoxProjectiles, RandomSpawnPoint, Quaternion.identity);
            C_Managment.Instance.AddItems();
        }
    }

    private void ManageBossLife()
    {
        if (BossLife.GetBossLife() < 0.05f)
        {
            C_Managment.Instance.PlayerController.SetPlayersWinner(true);
            C_Managment.Instance.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            BossLife.SetBossLife(0);
        }
    }
    
}

using UnityEngine;

public class C_BossManager : MonoBehaviour
{
    private ELevel CurrentLevel => C_Managment.Instance.GetCurrentLevel();
    private C_BossLife BossLife => C_Managment.Instance.BossLife;
    private C_BossPhases BossPhases => C_Managment.Instance.BossPhases;
    private bool bCanSpawn = true;

    [SerializeField] private GameObject BoxProjectiles;

    public void SetCanSpawn(bool Can) { bCanSpawn = Can; }
    // Update is called once per frame
    void Update()
    {
        if(BossPhases.GetCounterProjectiles() == 20 && bCanSpawn == true)
        {
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
}

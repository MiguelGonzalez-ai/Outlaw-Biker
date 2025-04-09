using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class C_LauncherManager : MonoBehaviour
{
    private int SuccesfullHits;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private int SpawnIntervals;
    [SerializeField] private GameObject Counter;

    void Start()
    {
        SuccesfullHits = 0;
        if(Counter != null)
        {
            TextMeshProUGUI text = Counter.GetComponent<TextMeshProUGUI>();
            text.text = "Counter: " + SuccesfullHits;
            InvokeRepeating("SpawnProyectil", 0, SpawnIntervals);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Counter != null)
        {
            TextMeshProUGUI text = Counter.GetComponent<TextMeshProUGUI>();
            text.text = "Counter: " + SuccesfullHits;
        }
    }

    public void SpawnProyectil()
    {
        if (Projectile == null) return;
        float RandomX = Random.Range(-7, 7);
        Vector3 RandomSpawnPoint = new Vector3(RandomX, -10, 0);
        Instantiate(Projectile, RandomSpawnPoint, Quaternion.identity);
    }

    
    public void IncreaseHits()
    {
        SuccesfullHits++;
    }


}

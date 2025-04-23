using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class C_LauncherManager : MonoBehaviour
{
    private TextMeshProUGUI CounterText;
    private TextMeshProUGUI MainText;
    private int SuccesfullHits;
    private int ProjectilesLaunched;
    private bool bFirstTime;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject Counter;
    [SerializeField] private GameObject Main;
    [SerializeField] private int MinimumProjectiles;
    [SerializeField] private float SpawnIntervals;
    [SerializeField] private float TimeMinigame;
    [SerializeField] private float TimeToChangeScene;

    void Start()
    {
        bFirstTime = true;
        DefaultSettings();
        GettingText();
        StartCoroutine(StartGame());
    }

    private void DefaultSettings()
    {
        SuccesfullHits = 0;
        ProjectilesLaunched = 0;
    }

    private void GettingText()
    {
        if (Counter != null && Main != null)
        {
            CounterText = Counter.GetComponent<TextMeshProUGUI>();
            MainText = Main.GetComponent<TextMeshProUGUI>();
            CounterText.text = "Counter: " + SuccesfullHits;
        }
        else return;
    }

    private IEnumerator StartGame()
    {
        CounterText.enabled = false;
        if (bFirstTime)
        {
            MainText.text = "You must shoot as many projectiles as possible, at least " + MinimumProjectiles;
        }
        else
        {
            MainText.text = "You lost, do it again";
        }
        yield return new WaitForSeconds(5);
        MainText.enabled = false;
        CounterText.enabled = true;
        InvokeRepeating("SpawnProyectil", 0, SpawnIntervals);
        StartCoroutine(StopGame(TimeMinigame));
    }

    private IEnumerator StopGame(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        CancelInvoke("SpawnProyectil");
        DecidingWinner();
    }

    private void DecidingWinner()
    {
        Debug.Log("Decidiendo");
        if (C_Managment.Instance == null) return;
        MainText.enabled = true;
        if (SuccesfullHits > MinimumProjectiles)
        {
            MainText.text = "You Won!!";
            StartCoroutine(C_Managment.Instance.ChangeScene(TimeToChangeScene));
            Debug.Log("Ganaste");
        }
        else
        {
            bFirstTime = false;
            Debug.Log("Perdiste");
            DefaultSettings();
            StartCoroutine(StartGame());
        }
    }

    void Update()
    {
        UpdatingCounter();
    }

    private void UpdatingCounter()
    {
        if (Counter != null)
        {
            CounterText.text = "Counter: " + SuccesfullHits;
        }
    }

    public void SpawnProyectil()
    {
        if (Projectile == null) return;
        float RandomX = Random.Range(-7, 7);
        Vector3 RandomSpawnPoint = new(RandomX, -10, 0);
        Instantiate(Projectile, RandomSpawnPoint, Quaternion.identity);
        ProjectilesLaunched++;
    }

    
    public void IncreaseHits()
    {
        SuccesfullHits++;
    }


}

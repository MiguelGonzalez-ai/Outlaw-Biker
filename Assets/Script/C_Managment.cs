using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public enum ELevel
{
    EL_AverageLevel,
    EL_BossLevel,
    EL_Minigame
}

public class C_Managment : MonoBehaviour
{

    public static C_Managment Instance { get; private set; }

    public GameObject Player;
    public C_PlayerController PlayerController { get; private set; }
    public C_PlayerLife PlayerLife { get; private set; }
    public C_PlayerLaunchProjectiles PlayerLaunchProjectiles { get; private set; }
    public C_BossLife BossLife { get; private set; }
    public C_LevelSetup LevelSetup { get; private set; }
    private bool bIsPause;
    [SerializeField] private int AuxCollectibles;
    [SerializeField] private int CollectiblesCounter; //Contador de los collecionables recogidos
    [SerializeField] private List<C_EnemyController> Enemies = new List<C_EnemyController>();
    [SerializeField] private List<C_Item> Items = new List<C_Item>();
    private ELevel CurrentLevel;
    [SerializeField] private AudioClip SoundCollectible;
    [SerializeField] private string SceneNameToLoad;

    //Public Functions
    public void IncreaseCollectiblesCounter() { CollectiblesCounter++; }
    public IEnumerator ChangeScene(float WaitTime)
    {
        Debug.Log("Cambiando Escena");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(SceneNameToLoad);
    }
    public void Settings()
    {
        Debug.Log("Settings");
        DefaultSettings();
        if(CurrentLevel != ELevel.EL_Minigame)
        {
            PlayerComponents();
        }
        CurrentLevelSettings();
    }
    //Setters
    public void SetCurrentLevel(ELevel Level) { CurrentLevel = Level; }
    public void SetSceneToLoad(string Scene) { SceneNameToLoad = Scene; }
    //Getters
    public ELevel GetCurrentLevel() { return CurrentLevel; }
    public bool GetIsPaused() { return bIsPause; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        //Settings();
        DontDestroyOnLoad(gameObject);
        AuxCollectibles = 1;
        CollectiblesCounter = 0;

    }

    private void DefaultSettings()
    {
        bIsPause = false;
        if (CurrentLevel != ELevel.EL_Minigame)
        {
            Items = new List<C_Item>(FindObjectsByType<C_Item>(FindObjectsSortMode.None));
        }
    }
    

    private void PlayerComponents()
    {
        Player = FindFirstObjectByType<C_PlayerController>().gameObject;
        if (Player != null)
        {
            PlayerController = Player.GetComponent<C_PlayerController>();
            PlayerLife = Player.GetComponent<C_PlayerLife>();
            if (Player.GetComponent<C_PlayerLaunchProjectiles>() != null)
            {
                PlayerLaunchProjectiles = Player.GetComponent<C_PlayerLaunchProjectiles>();
            }
        }
    }

    private void CurrentLevelSettings()
    {
        switch (CurrentLevel)
        {
            case ELevel.EL_AverageLevel:
                Debug.Log("Promedio");
                Enemies = new List<C_EnemyController>(FindObjectsByType<C_EnemyController>(FindObjectsSortMode.None));
                break;
            case ELevel.EL_BossLevel:
                BossLife = FindFirstObjectByType<C_BossLife>();
                break;
            case ELevel.EL_Minigame:
                Debug.Log("Minijuego");
                IncreaseCollectiblesCounter();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseManagment();
        }
        SoundManagment();
    }

    private void PauseManagment()
    {
        Time.timeScale = (!bIsPause) ? 0f : 1f;
        if (CurrentLevel != ELevel.EL_Minigame && Items != null)
        {
            foreach(C_Item Item in Items)
            {
                Item.SetItemState(!bIsPause ? EItemState.EIS_Pause : EItemState.EIS_Hovering);
            }
        }

        bIsPause = !bIsPause;

    }

    

    private void SoundManagment()
    {
        if (CollectiblesCounter == AuxCollectibles)
        {
            PlaySoundCollectible();
        }
    }

    private void PlaySoundCollectible()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundCollectible);
        AuxCollectibles = CollectiblesCounter + 1;
    }
    
}

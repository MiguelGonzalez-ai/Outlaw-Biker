using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class C_PlayerLife : MonoBehaviour
{
    private enum ELevelPlayer
    {
        ELP_AverageLevel,
        ELP_BossLevel
    }
    private Vector2 Spawn;
    [SerializeField] private ELevelPlayer CurrentLevel;
    [SerializeField] private Image PlayerLife;


    void Start()
    {
        PlayerLife.fillAmount = 1;
        Spawn = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerLife.fillAmount < 0.05f)
        {
            ChangingPlayerLevel();
        }
    }

    private void ChangingPlayerLevel()
    {
        switch (CurrentLevel)
        {
            case ELevelPlayer.ELP_AverageLevel:
                transform.position = Spawn;
                PlayerLife.fillAmount = 1;
                break;
            case ELevelPlayer.ELP_BossLevel:
                Destroy(gameObject);
                break;
        }
    }

    public void Healing(float Amount)
    {
        PlayerLife.fillAmount = Mathf.Clamp(PlayerLife.fillAmount + Amount, 0, 1);
    }

    public void TakingDamage(float Amount)
    {
        PlayerLife.fillAmount = Mathf.Clamp(PlayerLife.fillAmount - Amount, 0, 1);
    }
}

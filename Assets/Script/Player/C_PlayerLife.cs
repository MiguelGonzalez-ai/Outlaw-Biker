using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class C_PlayerLife : MonoBehaviour
{

    private Vector2 Spawn;
    [SerializeField] private ELevel CurrentLevel => C_Managment.Instance.GetCurrentLevel();
    [SerializeField] private Image PlayerLife;

    //Public Functions
    public void Healing(float Amount)
    {
        PlayerLife.fillAmount = Mathf.Clamp(PlayerLife.fillAmount + Amount, 0, 1);
    }
    public void TakingDamage(float Amount)
    {
        PlayerLife.fillAmount = Mathf.Clamp(PlayerLife.fillAmount - Amount, 0, 1);
    }


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
            case ELevel.EL_AverageLevel:
                transform.position = Spawn;
                PlayerLife.fillAmount = 1;
                break;
            case ELevel.EL_BossLevel:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}

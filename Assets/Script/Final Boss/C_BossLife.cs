using UnityEngine;
using UnityEngine.UI;

public class C_BossLife : MonoBehaviour
{
    [SerializeField] private Image BossLife;

    /*
     * Getter
     */
    public float GetBossLife() { return BossLife.fillAmount; }

    void Start()
    {
        BossLife.fillAmount = 1;
    }

    public void TakingDamage(float Damage)
    {
        BossLife.fillAmount = Mathf.Clamp(BossLife.fillAmount - Damage, 0, 1);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class C_BossLife : MonoBehaviour
{
    [SerializeField] Image BossLife;
    void Start()
    {
        BossLife.fillAmount = 1;
    }

    public void TakingDamage(float Damage)
    {
        BossLife.fillAmount = Mathf.Clamp(BossLife.fillAmount - Damage, 0, 1);
    }

    public float GetBossLife() { return BossLife.fillAmount; }
}

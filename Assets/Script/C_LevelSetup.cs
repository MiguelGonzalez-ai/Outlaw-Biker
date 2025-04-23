using UnityEngine;

public class C_LevelSetup : MonoBehaviour
{
    [SerializeField] ELevel Level;
    [SerializeField] string NextScene;
    void Awake()
    {
        if (C_Managment.Instance != null)
        {
            C_Managment.Instance.SetCurrentLevel(Level);
            C_Managment.Instance.SetSceneToLoad(NextScene);
            C_Managment.Instance.Settings();
        }
    }

    private void Start()
    {
        C_Managment.Instance.Settings();
    }

}

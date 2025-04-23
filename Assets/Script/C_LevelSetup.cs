using UnityEngine;

public class C_LevelSetup : MonoBehaviour
{
    [SerializeField] ELevel Level;
    [SerializeField] string NextScene;
    void Awake()
    {
        if (C_Managment.Instance != null)
        {
            Debug.ClearDeveloperConsole();
            C_Managment.Instance.SetCurrentLevel(Level);
            C_Managment.Instance.SetSceneToLoad(NextScene);
            C_Managment.Instance.Settings();
        }
    }
    

}

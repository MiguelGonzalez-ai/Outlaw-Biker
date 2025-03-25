using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class C_Item : MonoBehaviour
{
    protected GameObject Management;
    protected C_Managment AccessManagement;
    [SerializeField] protected float Amplitude;
    [SerializeField] protected float RunningTime;
    [SerializeField] protected float TimeConstant;
    
    private void Start()
    {
        Management = FindFirstObjectByType<C_Managment>().gameObject;
        if (Management != null)
        {
            AccessManagement = Management.GetComponent<C_Managment>();
        }
    }

    void Update()
    {
        OffsetItem();
    }

    protected virtual void OffsetItem()
    {
        RunningTime += Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + OffsetSin());
    }

    protected virtual float OffsetSin()
    {
        return Amplitude * Mathf.Sin(TimeConstant * RunningTime);
    }
}

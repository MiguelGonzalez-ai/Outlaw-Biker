using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
public enum EItemState
{
    EIS_Hovering,
    EIS_Pause
}
public class C_Item : MonoBehaviour
{
    protected GameObject Management;
    protected C_Managment AccessManagement;
    protected EItemState ItemState;
    [SerializeField] protected float Amplitude;
    [SerializeField] protected float RunningTime;
    [SerializeField] protected float TimeConstant;

    //Setters
    public virtual void SetItemState(EItemState State) { ItemState = State; }
    
    protected virtual void Update()
    {
        if (ItemState == EItemState.EIS_Pause) return;
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

using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class C_ProjectileMiniGame : C_Projectile
{
    private GameObject LauncheManager;
    private C_LauncherManager Hit;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;

    protected override void Start()
    {
        
        Direction();
        LauncheManager = FindFirstObjectByType<C_LauncherManager>().gameObject;
        if(LauncheManager != null)
        {
            Hit = LauncheManager.GetComponent<C_LauncherManager>();
            SpeedY = Random.Range(minForce, maxForce);
        }
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    

    private void OnMouseDown()
    {
        if (C_Managment.Instance.GetIsPaused()) return;
        if (gameObject.CompareTag("Ball"))
        {
            Hit.IncreaseHits();
            Destroy(gameObject);
            
        }
    }

    

}

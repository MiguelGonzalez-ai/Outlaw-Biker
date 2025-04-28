using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class C_ProjectileMiniGame : C_Projectile
{
    private GameObject LauncheManager;
    private C_LauncherManager Hit;
    [SerializeField] private int DirectionRotation;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;

    protected override void Start()
    {
        base.Start();
        Direction();
        LauncheManager = FindFirstObjectByType<C_LauncherManager>().gameObject;
        if(LauncheManager != null)
        {
            Hit = LauncheManager.GetComponent<C_LauncherManager>();
            SpeedY = Random.Range(minForce, maxForce);
            StartCoroutine(Launch(WaitTime));
        }

    }

    private void FixedUpdate()
    {

        transform.Rotate(Vector3.forward, RotationSpeed * DirectionRotation * Time.deltaTime);
    }

    private void Direction()
    {
        int Aux = Random.Range(1, 10);
        DirectionRotation = (Aux >= 6) ? 1 : -1;  
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

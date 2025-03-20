using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int velocidadRotacion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, velocidadRotacion);

    }
}

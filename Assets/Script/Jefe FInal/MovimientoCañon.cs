using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MovimientoCañon : MonoBehaviour
{
    public Transform jugador;
    public Image vida;
    public bool contactoCañon = false;
    Vector2 direccion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida.fillAmount <= 0.5 && contactoCañon)
        {
            rotacionCañon();
        }
        else
        {
            //transform.rotation = Quaternion.identity;
        }
    }

    private void rotacionCañon()
    {
        direccion = ((Vector2)jugador.position - (Vector2)transform.position).normalized;
        transform.right = direccion;
    }
}

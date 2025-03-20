using UnityEngine;
using UnityEngine.Windows;

public class ProyectilJugador : MonoBehaviour
{
    public float vx;
    public float vy;
    public float daño;
    public int lado = 1;
    Rigidbody2D rb;
    GameObject jefe;
    JefeFinal vida;

    void Start()
    {
        jefe = FindFirstObjectByType<JefeFinal>().gameObject;
        vida = jefe.GetComponent<JefeFinal>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 move = new Vector2(lado*vx, vy);
        rb.linearVelocity = move;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jefe")
        {
            vida.vida.fillAmount = Mathf.Clamp(vida.vida.fillAmount - daño, 0f, 1f);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(gameObject);

        }
    }

}

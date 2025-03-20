using System.Collections;
using UnityEngine;

public class ProyectilJefeFinal : MonoBehaviour
{
    public AnimationCurve trayectoriaProyectil;
    Rigidbody2D rb;
    GameObject jugador;
    Transform pos;
    controladorJugador vida;
    Vector2 posicionJugador;
    Vector2 posicionInicial;
    public int velocidad;
    public float duracion = 4f;
    public float alturaMaxima = 5f;
    public float tiempoTranscurrido;

    void Start()
    {
        posicionInicial = transform.position;
        jugador = FindFirstObjectByType<controladorJugador>().gameObject;
        pos = jugador.GetComponent<Transform>();
        posicionJugador = (Vector2)pos.position;
        vida = jugador.GetComponent<controladorJugador>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        float tiempo = tiempoTranscurrido / duracion;
        if (tiempo <= duracion)
        {
            Vector2 posicion = Vector2.Lerp(posicionInicial, posicionJugador, tiempo);
            posicion.y = trayectoriaProyectil.Evaluate(tiempo);
            transform.position = posicion;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            vida.vidaJugador.fillAmount = Mathf.Clamp(vida.vidaJugador.fillAmount - 0.2f, 0f, 1f);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(gameObject);

        }
    }


}

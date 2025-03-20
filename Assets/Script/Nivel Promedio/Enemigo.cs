using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject proyectil;
    public Proyectil lado;
    public Transform ladoIzq;
    public bool contactoIzq = false;
    public bool contactoDer = false;
    public int aux = 0;
    int aux2 = -1; //Permite rotar el personaje y cambiar la velocidad



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (contactoIzq == true && aux == 0)
        {
            aux = 1;
            InvokeRepeating("spawnProyectilIzq", 2f, 2f);
        }
        else if (contactoIzq == false && aux == 1)
        {
            aux = 0;
            CancelInvoke("spawnProyectilIzq");
        }

        if (contactoDer == true && aux == 0)
        {
            aux = 2;
            transform.localScale = new Vector3(aux2, 1, 1);
            aux2 *= -1;
        }
        else if (contactoDer == false && aux == 2)
        {
            aux = 0;
        }

    }

    public void spawnProyectilIzq()
    {
        lado.aux = aux2;
        Instantiate(proyectil, ladoIzq.position, Quaternion.identity);

    }
}

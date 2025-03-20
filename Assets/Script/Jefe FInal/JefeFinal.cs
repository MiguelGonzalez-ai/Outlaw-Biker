using UnityEngine;
using UnityEngine.UI;

public class JefeFinal : MonoBehaviour
{
    public Image vida;
    //Posicion proyectiles fase 1
     //Proyectiles
    //Movimiento Camion
    Vector2 posicionA;
    Vector2 siguientePosicion;
    public Transform posicionB;
    public float velocidadCamion;
    public float contadorProyectiles = 0;
    Collider2D colision;
    public int fase = 1;
    //fase 1
    public Transform fase1;
    public GameObject proyectil;    
    public AnimationCurve Trayectoria;
    public int lado = 1;
    public float zona;
    //fase 2
    public Transform fase2;
    public Transform pivoteCañon;
    public GameObject proyectil2;
    public bool contacto = false;

    


    void Start()
    {
        //InvokeRepeating("lanzamiento", 0f, 1f);
        siguientePosicion = (Vector2)posicionB.position;
        posicionA = (Vector2)transform.position;
        colision = GetComponent<Collider2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fase == 0 && vida.fillAmount <= 0.5)
        {
            fase = 2;
        }else if( vida.fillAmount < 0.05f)
        {
            Destroy(gameObject);
        }
        

        if(fase == 1) {
            fase = 0;
            InvokeRepeating("lanzamiento", 0f, 1f);
            
        }else if(fase == 2)
        {
            fase = 3; //Desactivacion fases;
            CancelInvoke("lanzamiento");
            InvokeRepeating("lanzamientoFase2", 0f, 2f);
        }

        if (contadorProyectiles >= 20) //Movimiento carro
        {
            transform.position = Vector2.MoveTowards(transform.position, siguientePosicion, velocidadCamion * Time.deltaTime);
            colision.isTrigger = true;
            
            if (Vector2.Distance((Vector2)transform.position, siguientePosicion) < 0.1f)
            {
                siguientePosicion = (Vector2.Distance(transform.position, posicionA) < 0.1f) ? posicionB.position : posicionA;
                contadorProyectiles = 0;
                
                //Rotar Camion
                transform.Rotate(transform.position.x, transform.position.y+180, 0);
                //Activar colision camion
                colision.isTrigger = false;
            }
        }
    }

    public void lanzamiento()
    {

        if (contacto) { 
            ProyectilJefeFinal proyectilAux = Instantiate(proyectil, fase1.position, Quaternion.identity).GetComponent<ProyectilJefeFinal>();
            proyectilAux.trayectoriaProyectil = Trayectoria;
            contadorProyectiles++;
        }
    }

    private void lanzamientoFase2()
    {
        if (contacto)
        {
            Instantiate(proyectil2, fase2.position, pivoteCañon.transform.rotation);
            contadorProyectiles++;
        }
        
    }
}

using UnityEngine;

public class Nivel : MonoBehaviour
{
    public controladorJugador jugador;
    public int nivel;
    void Start()
    {
        jugador.nivel = nivel; //Decide si es un nivel normal o el jefe final
    }

}

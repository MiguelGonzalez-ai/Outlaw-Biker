using UnityEngine;

public class C_End : MonoBehaviour
{
    /*
     * 
     * --------Explicacion Clase--------
     * Cuando el jugador llegue a la meta, se desactivara el control del jugador
     *
     */

    GameObject Player;
    C_PlayerController Movement;
    [SerializeField] GameObject WinningText;

    void Start()
    {
        Player = FindFirstObjectByType<C_PlayerController>().gameObject;
        if (Player != null) //Verifica si el jugador existe en la escena
        {
            Movement = Player.GetComponent<C_PlayerController>();
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró ningún objeto con C_PlayerController en la escena.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Movement.Winner = true;
            WinningText.SetActive(true);
        }
    }
}

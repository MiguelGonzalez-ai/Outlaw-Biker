using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_End : MonoBehaviour
{
    /*
     * 
     * --------Explicacion Clase--------
     * Cuando el jugador llegue a la meta, se desactivara el control del jugador
     *
     */

    private C_PlayerController Movement => C_Managment.Instance.PlayerController;
    [SerializeField] private GameObject WinningText;
    [SerializeField] private float TimeToChangeScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Movement.SetPlayersWinner(true);
            WinningText.SetActive(true);
            StartCoroutine(C_Managment.Instance.ChangeScene(TimeToChangeScene));
        }
    }

}

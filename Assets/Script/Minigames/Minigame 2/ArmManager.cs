using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArmManager : MonoBehaviour
{
    private bool bWinner;
    private bool bFirstTime;
    [SerializeField] private GameObject Text;
    [SerializeField] private Image Bar;
    [SerializeField] private float WaitTimeToStart;
    [SerializeField] private float PlayersForce;
    [SerializeField] private float OppositeForce;
    

    

    void Start()
    {
        bWinner = true;
        bFirstTime = true;
        StartCoroutine(StartingGame(WaitTimeToStart));
        Bar.fillAmount = 0.5f;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!bWinner) {
            InputsBar();
            EndGame();
        }
        
        
    }

    private void InputsBar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseForce(PlayersForce);
        }
        DecreaseForce(OppositeForce);
    }
    
    private void EndGame()
    {
        TextMeshProUGUI EndGameText = Text.GetComponent<TextMeshProUGUI>();
        if (Bar.fillAmount >= 0.99)
        {
            bWinner = true;
            EndGameText.text = "You Won!!";

        }
        else if (Bar.fillAmount == 0)
        {
            bWinner = true;
            bFirstTime = false;
            EndGameText.text = "You Lost...";
            StartCoroutine(StartingGame(WaitTimeToStart));
            
        }
    }
    IEnumerator StartingGame(float WaitTime)
    {
        TextMeshProUGUI texto = Text.GetComponent<TextMeshProUGUI>();
        if (!bFirstTime)
        {
            yield return new WaitForSeconds(3);
            Bar.fillAmount = 0.5f;
            texto.text = "Do it Again...";
            yield return new WaitForSeconds(3);
        }

        texto.text = "" + WaitTime;
        while (WaitTime > 0)
        {
            yield return new WaitForSeconds(1);
            WaitTime--;
            texto.text = ""+ WaitTime;
            if (WaitTime == 0)
            {
                texto.text = "¡¡VAMOS!!";
                bWinner = false;
            }
        }
    }
    public void IncreaseForce(float force)
    {
        Bar.fillAmount = Mathf.Clamp(Bar.fillAmount + force, 0f, 1f);
    }

    public void DecreaseForce(float force)
    {
        
        Bar.fillAmount = Mathf.Clamp(Bar.fillAmount - (force*Time.deltaTime), 0f, 1f);

    }
}

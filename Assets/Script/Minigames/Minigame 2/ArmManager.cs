using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArmManager : MonoBehaviour
{
    private enum ERoundArm : int
    {
        ERA_Round1 = 1,
        ERA_Round2,
        ERA_Round3,
        ERA_ArmWon
    }
    TextMeshProUGUI TextCounter;
    TextMeshProUGUI TextInstructions;
    private bool bStart;
    private bool bFirstTime;
    private bool bWon;
    private float CurrentOppositeForce;
    [SerializeField] private GameObject Counter;
    [SerializeField] private GameObject Instructions;
    [SerializeField] private Image Bar;
    [SerializeField] ERoundArm CurrentRound;
    [SerializeField] private float WaitTimeToChangeScene;
    [SerializeField] private float WaitTimeToStart;
    [SerializeField] private float PlayersForce;
    [SerializeField] private float ForceRound1;
    [SerializeField] private float ForceRound2;
    [SerializeField] private float ForceRound3;


    void Start()
    {
        bStart = false;
        bFirstTime = true;
        bWon = false;
        Bar.fillAmount = 0.5f;
        ChangingRound();
        if (Counter != null && Instructions != null)
        {
            TextCounter = Counter.GetComponent<TextMeshProUGUI>();
            TextInstructions = Instructions.GetComponent<TextMeshProUGUI>();
            StartCoroutine(StartingGame(WaitTimeToStart));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bStart) {
            InputsBar();
            CurrentRoundArm();
        }
        
        
    }

    private void InputsBar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseForce(PlayersForce);
        }
        DecreaseForce(CurrentOppositeForce);
    }
    
    private void CurrentRoundArm()
    {
        if (Bar.fillAmount >= 0.99)
        {
            CurrentRound++;
            bStart = false;
            ChangingRound();
            if (CurrentRound == ERoundArm.ERA_ArmWon) return;
            Bar.fillAmount = 0.5f;
            bFirstTime = false;
            bWon = true;
            TextInstructions.enabled = false;
            StartCoroutine(StartingGame(WaitTimeToStart));
        }
        else if (Bar.fillAmount == 0)
        {
            bFirstTime = false;
            bStart = false;
            bWon = false;
            TextInstructions.text = "You lost...";
            StartCoroutine(StartingGame(WaitTimeToStart));

        }
    }

    private void ChangingRound()
    {
        
        switch(CurrentRound)
        {
            case ERoundArm.ERA_Round1:
                Debug.Log("Round 1");
                CurrentOppositeForce = ForceRound1;
                break;
            case ERoundArm.ERA_Round2:
                Debug.Log("Round 2");
                CurrentOppositeForce = ForceRound2;
                break;
            case ERoundArm.ERA_Round3:
                Debug.Log("Round 3");
                CurrentOppositeForce = ForceRound3;
                break;
            case ERoundArm.ERA_ArmWon:
                Debug.Log("Ganaste");
                TextInstructions.text = "You Won!! ";
                if(C_Managment.Instance != null)
                {
                    StartCoroutine(C_Managment.Instance.ChangeScene(WaitTimeToChangeScene));
                }
                break;
        }
    }

    IEnumerator StartingGame(float WaitTime)
    {
        if(bFirstTime)
        {
            TextInstructions.text = "You must press 'space' to push the bar and win at least 3 rounds";
        }
        else if(!bFirstTime && !bWon)
        {
            yield return new WaitForSeconds(3);
            Bar.fillAmount = 0.5f;
            TextInstructions.text = "Do it Again...";
            yield return new WaitForSeconds(3);
        }
        TextCounter.enabled = true;
        TextCounter.text = "" + WaitTime;
        while (WaitTime > 0)
        {
            yield return new WaitForSeconds(1);
            WaitTime--;
            TextCounter.text = ""+ WaitTime;
            if (WaitTime == 0)
            {
                TextCounter.enabled = false;
                TextInstructions.enabled = true;
                TextInstructions.text = "Round " + (int)CurrentRound;
                bStart = true;
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

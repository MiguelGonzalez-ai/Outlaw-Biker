using UnityEngine;

public class C_Managment : MonoBehaviour
{
    int Aux;
    [SerializeField] AudioClip SoundCollectible;
    public int CollectiblesCounter; //Contador de los collecionables recogidos

    void Start()
    {
        Aux = 1;
        CollectiblesCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(CollectiblesCounter == Aux)
        {
            PlaySoundCollectible();
        }
    }

    private void PlaySoundCollectible()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundCollectible);
        Aux = CollectiblesCounter + 1;
    }
}

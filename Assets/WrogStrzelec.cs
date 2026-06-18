using UnityEngine;

public class WrogStrzelec : MonoBehaviour
{
    public GameObject pociskPrefab; // Miejsce na nasz niebieski pocisk
    public Transform punktStrzalu;  // Miejsce wystrzału
    public float czasMiedzyStrzalami = 2.0f; // Co ile sekund strzela
    
    private float licznik;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        licznik = czasMiedzyStrzalami; // Ustawiamy stoper
    }

    void Update()
    {
        // Odliczamy czas do zera
        licznik -= Time.deltaTime;

        if (licznik <= 0f)
        {
            // Odpalamy animację strzału (jeśli ją masz)
            if (anim != null) anim.SetTrigger("Strzal");
            
            // Klonujemy pocisk!
            Instantiate(pociskPrefab, punktStrzalu.position, Quaternion.identity);
            
            // Resetujemy stoper od nowa
            licznik = czasMiedzyStrzalami;
        }
    }
}

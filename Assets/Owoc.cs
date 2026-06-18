using UnityEngine;

public class Owoc : MonoBehaviour
{
    private Animator anim;
    
    // Zmienna, która pilnuje, czy jabłko zostało już dotknięte
    private bool czyZebrany = false; 

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Sprawdzamy: czy to gracz ORAZ czy jabłko nie zostało jeszcze zebrane
        if (collision.CompareTag("Player") && czyZebrany == false)
        {
            czyZebrany = true; // ZATRZASKUJEMY KŁÓDKĘ! Od teraz jabłko jest "zużyte".

            FindObjectOfType<Licznik>().DodajPunkt();

            anim.SetTrigger("Zjedzony");
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
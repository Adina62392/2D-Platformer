using UnityEngine;

public class Trampolina : MonoBehaviour
{
    public float silaWybicia = 15f; // Możesz to zmieniać w Inspectorze!
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzamy, czy to gracz naskoczył na trampolinę
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Skok"); // Odpalamy animację

            // Znajdujemy fizykę gracza i wystrzeliwujemy go w kosmos!
            Rigidbody2D rbGracza = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rbGracza != null)
            {
                // Zatrzymujemy jego dotychczasowe spadanie i nadajemy potężną siłę w górę
                rbGracza.linearVelocity = new Vector2(rbGracza.linearVelocity.x, silaWybicia);
            }
        }
    }
}
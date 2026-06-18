using UnityEngine;

public class Ostrze : MonoBehaviour
{
    // Używamy OnCollisionEnter2D dla twardych zderzeń (gdy Is Trigger jest odznaczone)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzamy, czy obiekt, który uderzył w pułapkę, ma Tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Znajdujemy u gracza Twój skrypt zdrowia i zabieramy mu 1 życie
            collision.gameObject.GetComponent<PlayerHealth>().AddDamage(1f);
        }
    }
}
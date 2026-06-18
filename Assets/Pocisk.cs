using UnityEngine;

public class Pocisk : MonoBehaviour
{
    public float predkosc = 5f;

    void Start()
    {
        // Automatycznie niszczymy pocisk po 3 sekundach, żeby nie leciał w nieskończoność
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Pocisk leci cały czas w lewo
        transform.Translate(Vector3.left * predkosc * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jeśli pocisk trafi w gracza...
        if (collision.CompareTag("Player"))
        {
            // ...zabiera mu życie i niszczy sam siebie
            collision.GetComponent<PlayerHealth>().AddDamage(1f);
            Destroy(gameObject);
        }
    }
}
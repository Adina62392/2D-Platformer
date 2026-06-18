using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] punktyTrasy; // Przeciągniesz tu punkty A i B
    public float szybkosc = 2f;
    private int celIndex = 0;

    void Update()
    {
        // 1. Ruch w stronę punktu
        Transform cel = punktyTrasy[celIndex];
        transform.position = Vector2.MoveTowards(transform.position, cel.position, szybkosc * Time.deltaTime);

        // 2. Sprawdzanie czy dotarliśmy
        if (Vector2.Distance(transform.position, cel.position) < 0.1f)
        {
            celIndex++; // Następny punkt
            if (celIndex >= punktyTrasy.Length) celIndex = 0; // Powrót do początku

            // 3. Odwracanie grafiki (Flip)
            // Jeśli idziemy w prawo, obracamy w prawo, itd.
            Vector3 kierunek = cel.position - transform.position;
            if (kierunek.x != 0)
            {
                transform.localScale = new Vector3(kierunek.x > 0 ? 1 : -1, 1, 1);
            }
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().AddDamage(1f);
        }
    }
}

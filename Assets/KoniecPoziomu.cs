using UnityEngine;
using UnityEngine.SceneManagement;

public class KoniecPoziomu : MonoBehaviour
{
    private Licznik skryptLicznik;

    [Header("Ustawienia Finału")]
    public bool czyToOstatniPoziom = false; // Ptaszek, którym zdecydujesz, czy to koniec gry
    public GameObject ekranWygranej;        // Tu przeciągniemy Twój napis

    private void Start()
    {
        // Upewniamy się, że czas płynie normalnie (przydatne przy restartach)
        Time.timeScale = 1f;
        skryptLicznik = FindObjectOfType<Licznik>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (skryptLicznik != null && skryptLicznik.CzyZebranoWszystko())
            {
                if (czyToOstatniPoziom)
                {
                    // Opcja A: To jest wielki finał!
                    if (ekranWygranej != null)
                    {
                        ekranWygranej.SetActive(true); // Włączamy ukryty napis
                    }
                    
                    // Zatrzymujemy czas w grze (postacie przestają się ruszać)
                    Time.timeScale = 0f; 
                }
                else
                {
                    // Opcja B: To zwykły poziom, ładujemy następny
                    int obecnyPoziom = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(obecnyPoziom + 1);
                }
            }
            else
            {
                Debug.Log("Jeszcze nie możesz przejść! Pozbieraj resztę jabłek.");
            }
        }
    }
}

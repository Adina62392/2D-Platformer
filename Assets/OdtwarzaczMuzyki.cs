using UnityEngine;

public class OdtwarzaczMuzyki : MonoBehaviour
{
    // Ta zmienna pamięta, czy mamy już odtwarzacz w grze
    private static OdtwarzaczMuzyki instancja;

    private void Awake()
    {
        // Sprawdzamy, czy w grze istnieje już jakaś muzyka
        if (instancja != null)
        {
            // Jeśli tak (np. wróciliśmy do 1 poziomu), niszczymy ten nowy duplikat
            Destroy(gameObject);
            return;
        }

        // Jeśli to pierwszy odtwarzacz, mianujemy go główną muzyką
        instancja = this;
        
        // Magiczna komenda: Nie niszcz tego obiektu przy ładowaniu nowej mapy!
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;
using TMPro; // Ważne: to pozwala nam sterować tekstem TextMeshPro!

public class Licznik : MonoBehaviour
{
    public int punkty = 0;
    public int wszystkieJablka; // Nowa zmienna na całkowitą liczbę jabłek
    private TextMeshProUGUI wyswietlacz;

    private void Start()
    {
        // Skrypt znajduje tekst podpięty do tego samego obiektu
        wyswietlacz = GetComponent<TextMeshProUGUI>();

        // Unity samo liczy wszystkie obiekty, które mają Tag "Owoc"
        wszystkieJablka = GameObject.FindGameObjectsWithTag("Owoc").Length;

        // Ustawiamy tekst na start (np. "Jabłka: 0 / 5")
        wyswietlacz.text = "Jabłka: " + punkty + " / " + wszystkieJablka;
    }

    // Tę funkcję będą wywoływać zjadane jabłka
    public void DodajPunkt()
    {
        punkty += 1; // Dodajemy 1 do puli
        
        // Aktualizujemy napis na ekranie po zjedzeniu
        wyswietlacz.text = "Jabłka: " + punkty + " / " + wszystkieJablka; 
    }

    // NOWA FUNKCJA - Meta zapyta tę funkcję, czy może przepuścić gracza
    public bool CzyZebranoWszystko()
    {
        return punkty >= wszystkieJablka;
    }
}

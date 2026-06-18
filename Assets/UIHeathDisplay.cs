using TMPro;
using UnityEngine;

public class UIHeathDisplay : MonoBehaviour
{
    //referencja do PlayerHealth
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
{
    // Jeśli nie mamy przypisanego gracza, szukamy go
    if (playerHealth == null)
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Dodajemy małe zabezpieczenie, żeby skrypt nie "wywalił się", 
    // jeśli z jakiegoś powodu gracza nie ma na mapie
    if (playerHealth != null)
    {
        playerHealth.OnHealthChanged += PlayerHealth_OnHealthChanged;
        playerHealth.OnHealthInit += OnHealthInit;
    }
    else
    {
        Debug.LogError("Nie znaleziono gracza na tej scenie!");
    }
}
    public void OnHealthInit(float newHealth)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString() + "<color=red>♥</color>";
     
    }
    private void PlayerHealth_OnHealthChanged(float health, float amountChanged)
    {
       healthText.text = health.ToString() + "<color=red>♥</color>";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        playerHealth.OnHealthChanged += PlayerHealth_OnHealthChanged;
        playerHealth.OnHealthInit += OnHealthInit;

    }
    public void OnHealthInit(float newHealth)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
     
    }
    private void PlayerHealth_OnHealthChanged(float health, float amountChanged)
    {
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

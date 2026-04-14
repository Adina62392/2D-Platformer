using TMPro;
using UnityEngine;

public class UIHeathDisplay : MonoBehaviour
{
    //referencja do PLayerHealth
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitialised += OnHealthInit;

    }
    public void OnHealthInit(float newHealth, float amountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
     
    }
    private void PlayerHealth_OnHealthChanged(float health, float amountChanged)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

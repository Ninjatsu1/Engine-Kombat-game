using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isEnemy = true;
    public Healthbar healthbar;
    private int count;
    public ParticleSystem sparks;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (isEnemy)
            {
                GameManager.instance.enemies.Remove(gameObject);
                Destroy(gameObject);
            }
            else
            {
                string gameState = "Your tank exploded!";
                PlayerPrefs.SetString("gameState", gameState);
                SceneManager.LoadScene("Ending");
            }
            
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        sparks.Play();
    }
}

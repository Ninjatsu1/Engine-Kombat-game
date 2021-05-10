using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject[] enemyArray;
    public List<GameObject> enemies;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        listEnemies();
    }
    private void Update()
    {
        Win();
    }
    // Start is called before the first frame update
    private void Win()
    {
        if (enemies.Count == 0)
        {
            string gameState = "Your tank won!";
            PlayerPrefs.SetString("gameState", gameState);
            SceneManager.LoadScene("Ending");
        }
    }
    private void listEnemies()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<GameObject>(enemyArray);
    }
}

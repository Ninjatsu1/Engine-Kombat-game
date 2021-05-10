using UnityEngine;
using TMPro;
public class Ending : MonoBehaviour
{
    public TextMeshProUGUI endingText;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        endingText.text = PlayerPrefs.GetString("gameState");

        if (endingText.text == "Tank exploded")
        {
            explosion.SetActive(true);
        }
        else
        {
            Debug.Log("Winning");
        }
    }

}

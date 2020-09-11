using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
        
    } // called everytime a game object is enabled

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("GO to menu");
    }
}

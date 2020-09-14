using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        //if enabled, this will disable and if disabled, it will enable
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            // game will be paused including time.deltatime
            // to double the speed of time in game, set time.fixeddeltatime to 2f  
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        //Time.timeScale = 1f;
        // or 
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {

    }

}

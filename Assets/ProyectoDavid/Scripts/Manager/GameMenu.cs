using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{//https://www.youtube.com/watch?v=8Q9prb7PH9g&list=PLeWwtNsNObD2Pv7e7q8D0OZaz62PSR-va
    public Image gameMenuImage;
    private void Start()
    {
        gameMenuImage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          //  Debug.Log("funciona");
            if (GameManager.instance.isPaused)// si apretamos esc y el juego esta en pausa
            {
                Resume();
            }
            else
            {
                Pause();
            }                   
        }
    }
    public void Resume()
    {
      //  Debug.Log("resume");
        gameMenuImage.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }
    private void Pause()
    {
        //Debug.Log("paused"); gameMenuImage.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.isPaused = true;
    }
    //public void BGTM
}

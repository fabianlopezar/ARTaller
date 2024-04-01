using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour

{
    private bool JuegoPause = false;
    public GameObject panelPantallaInicial;

    public string sceneName;

    /*public void Awake()
    {
        Time.timeScale = 0f;
    }*/
    public void Jugar()
    {
        Time.timeScale = 1f;
        panelPantallaInicial.SetActive(false);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

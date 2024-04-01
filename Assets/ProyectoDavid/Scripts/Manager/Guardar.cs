using UnityEngine;
public class Guardar : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject camara;
    [SerializeField] GameObject[] arraySheep;
  
    //falta que cuando el jugado le de click a guardar imprima un mensaje "datos guardados"
    //public Text guardadoText;

    public void Awake()
    {
        LoadPlayerPosition();
       
    }
    
    public void SavePlayerPosition()
    {
        //--------------- Player ----------------------------------
        Vector3 playerPosition = Player.transform.position;
        PlayerPrefs.SetFloat("PlayerX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerY", playerPosition.y);
        PlayerPrefs.Save();
        //--------------- Camara ----------------------------------
        Vector3 camaraPosition = camara.transform.position;
        PlayerPrefs.SetFloat("CamaraX", camaraPosition.x);
        PlayerPrefs.SetFloat("CamaraY", camaraPosition.y);
        PlayerPrefs.Save();
    }
    public void LoadPlayerPosition()
    {
        //--------------- Player ----------------------------------
        float playerX = PlayerPrefs.GetFloat("PlayerX");
        float playerY = PlayerPrefs.GetFloat("PlayerY");
        Vector3 playerPosition = new Vector3(playerX, playerY, 0);
        Player.transform.position = playerPosition;
        //--------------- Camara ----------------------------------
        float camaraX = PlayerPrefs.GetFloat("CamaraX");
        float camaraY = PlayerPrefs.GetFloat("CamaraY");
        Vector3 camaraPosition = new Vector3(camaraX, camaraY, -10);
        camara.transform.position = camaraPosition;
     
    }
public void SaveSheep()
    {
      
    }
  
}

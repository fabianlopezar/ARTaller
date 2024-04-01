using UnityEngine;
using UnityEngine.UI;
public class FlechaTutorial : MonoBehaviour
{
    public Transform flecha;
    public GameObject[] misiones;
    public int numeroMision;
    public Text misionesText;
    public int enemyDeadOso;
    public int enemyDeadLeon;
    private void Start()
    {
        numeroMision = PlayerPrefs.GetInt("nMision");
    }
    private void Update()
    {     
        Vector3 direction = flecha.position - misiones[numeroMision].transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
             
    }
   

}

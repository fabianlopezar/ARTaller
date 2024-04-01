using System.Collections;
using UnityEngine;
public class Mapa : MonoBehaviour
{
    public GameObject mapa;
    public bool mapaOpen = false;
    void Start()
    {
        mapa.SetActive(false);
    }
    public void AbrirMapa()
    {
        if (mapaOpen == false)
        {
            mapa.SetActive(true);
            StartCoroutine(Espera());
            mapaOpen = true;
        }
        else 
        {
            mapa.SetActive(false);
            StartCoroutine(Espera());
            mapaOpen = false;
        }
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(0.5f);
    }
}

using System.Collections;
using UnityEngine;

public class Vara_Button : MonoBehaviour
{
    public GameObject vara;
    public GameObject[] ovejas;
    public bool vara_activa = false;
    public Animator animm;
    public void Ovejas_dejar_seguir()
    {
        for (int i = 0; i < ovejas.Length; i++)
        {
            // ovejas[i].GetComponent<Ovejas>().tieneLaVara = false ;
            ovejas[i].GetComponent<Sheeps>().tieneLaVara = false;

        }
        if (vara_activa == true)
        {
            vara.SetActive(false);
            StartCoroutine(Espera());
            vara_activa = false;
            animm.SetBool("vara", false);

        }
   else
        {
            vara.SetActive(true);
            StartCoroutine(Espera());
            vara_activa = true;
            animm.SetBool("vara",true);
        }
    }
   
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(0.5f);
    }
}

using UnityEngine;
public class Disparador : MonoBehaviour
{
    public GameObject ammunition;
    //posicion contenedor
    public Transform firePort;
    //tiempo a esperar
    public float recargarRoca;
    bool isFiring;
    bool stopFiring;
    //deberia poner un bloqueador para que no dispare tan seguido
    public void pointerDown()
    {
        stopFiring = false;
        makeFireVariableTrue();
        
    }

    public void pointerUp()
    {
        isFiring = false;
        stopFiring = true;
    }

    void makeFireVariableTrue()
    {
        isFiring = true;
        if (isFiring)
        {
            makeFireVariableFalse();
            Instantiate(ammunition, firePort.position, firePort.rotation);
            isFiring = false;
        }
    }

    void makeFireVariableFalse()
    {
        isFiring = false;
        if (stopFiring == false)
        {
         //   Invoke("makeFireVariableTrue", recargarRoca);
        }
    }

    void Update()
    {
        /*if (isFiring)
        {
            makeFireVariableFalse();
            Instantiate(ammunition, firePort.position, firePort.rotation);
        }*/

    }
}

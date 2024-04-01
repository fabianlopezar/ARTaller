using UnityEngine;

public class Misiones : MonoBehaviour
{
    public static Misiones Instance { get; set; }
    public int _numeroMision;


    public void Awake()
    {
        InstanciarClase();
    }

    private void InstanciarClase()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SiguienteMision()
    {
        _numeroMision++;
    }
}

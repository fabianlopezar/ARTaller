using UnityEngine;

/*public enum TiposDeItem
{
    Armas,Pociones,Pergaminos,Ingredientes,Tesoros
}*/
public class Item : ScriptableObject
{
    [Header("Parametros")]
    public string _ID;
    public string _nombre;
    public Sprite _icono;
    [TextArea] public string _descripcion;

    [Header("Informacion")]

    //public TiposDeItem _tipo;
    public bool _esConsumible;
    public bool _esAcumulable;
    public int _acumulacionMax;

    [HideInInspector] public int _cantidad;

    public Item CopiarItem()
    {
        Item nuevaInstancia = Instantiate(this);
        return nuevaInstancia;
    }
    
}

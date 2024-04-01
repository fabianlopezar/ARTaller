using UnityEngine;
using System;

//crear desde project, click derecho, create, quest.
[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public static Action<Quest> EventoQuestCompletado;
    [Header("Info")]
    public string _nombre;
    public string _ID;
    public int _cantidadObjetivo;

    [Header("Descripcion")]
    [TextArea] public string _descipcion;

    [Header("Recompensas")]
    public int _recompensaOro;
    public float _recompensaExp;
    public QuestRecompensaItem _recompensaItem;
    public int _cantidadActual;
    [HideInInspector] public bool _questCompletadoCheck;
    public bool _questAceptado=false;

    //Este m�todo permite aumentar el progreso actual de la misi�n en una cantidad determinada. Luego, verifica si la misi�n ha sido completada 
    public void A�adirProgreso(int cantidad)
    {
        _cantidadActual += cantidad;
        VerificarQuestCompletado();
    }

    //Comprueba si la cantidad actual de progreso ha alcanzado o superado la cantidad objetivo. Si es as�, llama a QuestCompletado.
    private void VerificarQuestCompletado()
    {
        if (_cantidadActual >= _cantidadObjetivo)
        {
            _cantidadActual = _cantidadObjetivo;
            QuestCompletado();
        }
    }

    //Marca la misi�n como completada, invocando el evento est�tico EventoQuestCompletado, que notifica a otros componentes del juego que la misi�n ha sido completada.
    private void QuestCompletado()
    {
        if (_questCompletadoCheck)
        {
            return;
        }
        _questCompletadoCheck = true;
        EventoQuestCompletado?.Invoke(this);

    }
    //Este m�todo se ejecuta cuando el ScriptableObject se habilita. Restablece las variables 
    private void OnEnable()
    {
        _questCompletadoCheck = false;
        _cantidadActual = 0;
    }

}
    //Esta linea sirve para porder ver la clase QuestRecompensaItem en el inspector.
    [Serializable]

    // Esta clase representa la informaci�n de un posible �tem de recompensa que puede otorgarse al completar la misi�n.
    public class QuestRecompensaItem
    {       
        public Item _item;
        public int _cantidad;
    }

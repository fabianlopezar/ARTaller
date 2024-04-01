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

    //Este método permite aumentar el progreso actual de la misión en una cantidad determinada. Luego, verifica si la misión ha sido completada 
    public void AñadirProgreso(int cantidad)
    {
        _cantidadActual += cantidad;
        VerificarQuestCompletado();
    }

    //Comprueba si la cantidad actual de progreso ha alcanzado o superado la cantidad objetivo. Si es así, llama a QuestCompletado.
    private void VerificarQuestCompletado()
    {
        if (_cantidadActual >= _cantidadObjetivo)
        {
            _cantidadActual = _cantidadObjetivo;
            QuestCompletado();
        }
    }

    //Marca la misión como completada, invocando el evento estático EventoQuestCompletado, que notifica a otros componentes del juego que la misión ha sido completada.
    private void QuestCompletado()
    {
        if (_questCompletadoCheck)
        {
            return;
        }
        _questCompletadoCheck = true;
        EventoQuestCompletado?.Invoke(this);

    }
    //Este método se ejecuta cuando el ScriptableObject se habilita. Restablece las variables 
    private void OnEnable()
    {
        _questCompletadoCheck = false;
        _cantidadActual = 0;
    }

}
    //Esta linea sirve para porder ver la clase QuestRecompensaItem en el inspector.
    [Serializable]

    // Esta clase representa la información de un posible ítem de recompensa que puede otorgarse al completar la misión.
    public class QuestRecompensaItem
    {       
        public Item _item;
        public int _cantidad;
    }

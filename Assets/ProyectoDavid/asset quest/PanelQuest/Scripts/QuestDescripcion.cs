using UnityEngine;
using TMPro;

public class QuestDescripcion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questNombre;
    [SerializeField] private TextMeshProUGUI _questDescripcion;

    //Se utiliza para hacer un seguimiento de la misi�n que se est� mostrando en el UI. La propiedad tiene un getter y un setter autom�ticos, lo que permite obtener o establecer el valor de QuestPorCompletar.
    public Quest QuestPorCompletar { get; set; }

    //Este m�todo es p�blico y virtual, lo que significa que puede ser sobrescrito por las clases que heredan de esta.Est� dise�ado para configurar la interfaz de usuario con la informaci�n de una misi�n espec�fica.
    public virtual void ConfigurarQuestUI(Quest quest)
    {
        QuestPorCompletar = quest;
        _questNombre.text = quest._nombre;
        _questDescripcion.text = quest._descipcion;
    }
}

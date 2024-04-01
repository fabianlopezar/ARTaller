using UnityEngine;
using TMPro;

public class QuestDescripcion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questNombre;
    [SerializeField] private TextMeshProUGUI _questDescripcion;

    //Se utiliza para hacer un seguimiento de la misión que se está mostrando en el UI. La propiedad tiene un getter y un setter automáticos, lo que permite obtener o establecer el valor de QuestPorCompletar.
    public Quest QuestPorCompletar { get; set; }

    //Este método es público y virtual, lo que significa que puede ser sobrescrito por las clases que heredan de esta.Está diseñado para configurar la interfaz de usuario con la información de una misión específica.
    public virtual void ConfigurarQuestUI(Quest quest)
    {
        QuestPorCompletar = quest;
        _questNombre.text = quest._nombre;
        _questDescripcion.text = quest._descipcion;
    }
}

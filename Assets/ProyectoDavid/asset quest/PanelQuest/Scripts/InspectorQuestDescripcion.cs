using TMPro;
using UnityEngine;
public class InspectorQuestDescripcion: QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI questRecompensa;

    //se agrega la funcionalidad específica para mostrar la información de recompensa de la misión.
    //Este método es público y reemplaza (override) un método llamado ConfigurarQuestUI de la clase padre 
    public override void ConfigurarQuestUI(Quest quest)
    {
        //Es una llamada al método ConfigurarQuestUI de la clase padre. Esto asegura que la implementación de la clase padre se ejecute antes de agregar la funcionalidad adicional en esta clase hija.
        base.ConfigurarQuestUI(quest);
        QuestPorCompletar = quest;
        questRecompensa.text = $"-{quest._recompensaOro} oro"+
            $"\n-{quest._recompensaExp} exp" +
            $"\n-{quest._recompensaItem._item._nombre} x{quest._recompensaItem._cantidad}" ;
   
    }
    public void AceptarQuest()
    {
        //Verifica si hay una misión para aceptar,Si no hay una misión válida para aceptar, simplemente sale del método sin realizar ninguna acción.
        if (QuestPorCompletar == null)
        {
            return;
        }

        //Agrega la misión QuestPorCompletar a la lista de misiones activas del jugador.
        QuestManager.Instance.AñadirQuest(QuestPorCompletar);

        //Desactiva el GameObject(el objeto al que está asociado este script) para que ya no se muestre en el UI.
        gameObject.SetActive(false);
    }

}

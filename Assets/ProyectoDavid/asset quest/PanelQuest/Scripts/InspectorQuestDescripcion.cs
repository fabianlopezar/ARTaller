using TMPro;
using UnityEngine;
public class InspectorQuestDescripcion: QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI questRecompensa;

    //se agrega la funcionalidad espec�fica para mostrar la informaci�n de recompensa de la misi�n.
    //Este m�todo es p�blico y reemplaza (override) un m�todo llamado ConfigurarQuestUI de la clase padre 
    public override void ConfigurarQuestUI(Quest quest)
    {
        //Es una llamada al m�todo ConfigurarQuestUI de la clase padre. Esto asegura que la implementaci�n de la clase padre se ejecute antes de agregar la funcionalidad adicional en esta clase hija.
        base.ConfigurarQuestUI(quest);
        QuestPorCompletar = quest;
        questRecompensa.text = $"-{quest._recompensaOro} oro"+
            $"\n-{quest._recompensaExp} exp" +
            $"\n-{quest._recompensaItem._item._nombre} x{quest._recompensaItem._cantidad}" ;
   
    }
    public void AceptarQuest()
    {
        //Verifica si hay una misi�n para aceptar,Si no hay una misi�n v�lida para aceptar, simplemente sale del m�todo sin realizar ninguna acci�n.
        if (QuestPorCompletar == null)
        {
            return;
        }

        //Agrega la misi�n QuestPorCompletar a la lista de misiones activas del jugador.
        QuestManager.Instance.A�adirQuest(QuestPorCompletar);

        //Desactiva el GameObject(el objeto al que est� asociado este script) para que ya no se muestre en el UI.
        gameObject.SetActive(false);
    }

}

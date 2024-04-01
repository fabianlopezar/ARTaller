using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PersonajeQuestDescripcion : QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI _tareaObjetivo;
    [SerializeField] private TextMeshProUGUI _recompensaOro;
    [SerializeField] private TextMeshProUGUI _recompensaExp;

    [Header("Item")]
    [SerializeField] private Image _recompesaItemIcono;
    [SerializeField] private TextMeshProUGUI _recompensaItemCantidad;

    private void Update()
    {
        if (QuestPorCompletar._questCompletadoCheck)
        {
            return;
        }
        _tareaObjetivo.text = $"{QuestPorCompletar._cantidadActual}/{QuestPorCompletar._cantidadObjetivo}";

    }

    public override void ConfigurarQuestUI(Quest questPorCargar)
    {
        base.ConfigurarQuestUI(questPorCargar);
        _recompensaOro.text = questPorCargar._recompensaOro.ToString();
        _recompensaExp.text = questPorCargar._recompensaExp.ToString();
        _tareaObjetivo.text = $"{questPorCargar._cantidadActual}/{questPorCargar._cantidadObjetivo}";

        //este codigo deberia funciona si creo la clase item
        //_recompesaItemIcono.sprite=questPorCargar._recompensaItem.Item.Icono
        _recompensaItemCantidad.text = questPorCargar._recompensaItem._cantidad.ToString();
    }
    private void QuestCompletadoRespuesta(Quest questCompletado)
    {
        if (questCompletado._ID == QuestPorCompletar._ID)
        {
            _tareaObjetivo.text = $"{QuestPorCompletar._cantidadActual}/{QuestPorCompletar._cantidadObjetivo}";
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        if (QuestPorCompletar._questCompletadoCheck)
        {
            gameObject.SetActive(false);
        }
        Quest.EventoQuestCompletado += QuestCompletadoRespuesta;
    }
    private void OnDisable()
    {
        Quest.EventoQuestCompletado -= QuestCompletadoRespuesta;
    }
}

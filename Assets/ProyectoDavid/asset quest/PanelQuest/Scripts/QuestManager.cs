using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Singleton asegura que solo exista una única instancia de la clase QuestManager durante toda la vida del juego.
public class QuestManager : Singleton<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest[] _questsDisponibles;

    [Header("Inspector Quests")]
    [SerializeField] private InspectorQuestDescripcion _inspectorQuestPrefab;
    [SerializeField] private Transform inspectorQuestContenedor;
    
    [Header("Personaje Quests")]
    [SerializeField] private PersonajeQuestDescripcion _personajeQuestPrefab;
    [SerializeField] private Transform personajeQuestContenedor;
    
    [Header("Panel Quests Completado")]
    [SerializeField] private GameObject panelQuestCompletado;
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questRecompensaOro;
    [SerializeField] private TextMeshProUGUI questRecompensaExp;
    [SerializeField] private TextMeshProUGUI questRecompensaItemCantidad;
    //[SerializeField] private Image questRecompensaIcono;

    [Header("Misiones")]
    public int muertesSoldados=0;
    private TargetIndicator _targetIndicator;
    

    public Quest QuestPorReclamar { get; private set; }

    
    private void Start()
    {
        CargarQuestEnInspector();
        _targetIndicator = GameObject.FindObjectOfType<TargetIndicator>();
    }
    
    //si se ha presionado la tecla "1, 2, 3". Si es así, llama al método AñadirProgreso con argumentos específicos (un ID de misión y una cantidad).
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            AñadirProgreso("1", 1);

        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            AñadirProgreso("2", 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {    
            AñadirProgreso("3", 1);
        }*/
    }

    //va a cargar todas las misiones disponibles
    private void CargarQuestEnInspector()
    {
        for (int i = 0; i < _questsDisponibles.Length; i++)
        {
            InspectorQuestDescripcion nuevoQuest= Instantiate(_inspectorQuestPrefab, inspectorQuestContenedor);
            nuevoQuest.ConfigurarQuestUI(_questsDisponibles[i]);
        }
    }
    private void AñadirQuestPorCompletar(Quest questPorCompletar)
    {
        PersonajeQuestDescripcion nuevoQuest = Instantiate(_personajeQuestPrefab, personajeQuestContenedor);
        nuevoQuest.ConfigurarQuestUI(questPorCompletar);
    }
    public void AñadirQuest(Quest questPorCompletar)
    {
        AñadirQuestPorCompletar(questPorCompletar);
    }
    public void AñadirProgreso(string questID, int cantidad)
    {
        Quest questPorActualizar = QuestExiste(questID);
   
        questPorActualizar.AñadirProgreso(cantidad);
    }
    private Quest QuestExiste(string questID)
    {
        for (int i = 0; i < _questsDisponibles.Length; i++)
        {
            if (_questsDisponibles[i]._ID == questID)
            {
                return _questsDisponibles[i];
            }
        }
        return null;
    }
    private void MostrarQuestCompletado(Quest questCompletado)
    {
        panelQuestCompletado.SetActive(true);
        questNombre.text = questCompletado._nombre;
        questRecompensaOro.text = questCompletado._recompensaOro.ToString();
        questRecompensaExp.text = questCompletado._recompensaExp.ToString();
        questRecompensaItemCantidad.text = questCompletado._recompensaItem._cantidad.ToString();
        
    }
    private void QuestCompletadoRespuesta(Quest questCompletado)
    {
        QuestPorReclamar = QuestExiste(questCompletado._ID);
        if (QuestPorReclamar != null)
        {
            _targetIndicator.SumarPosicionMision();// cambiar de pocision la flecha de misiones.
            MostrarQuestCompletado(QuestPorReclamar);
        }
    }
    private void OnEnable()
    {
        Quest.EventoQuestCompletado += QuestCompletadoRespuesta;
    }
    private void OnDisable()
    {
        Quest.EventoQuestCompletado -= QuestCompletadoRespuesta;
    }


    #region Misiones
    public void SumarTarea(int id)
    {
        switch (id)
        {
            case 1:
                muertesSoldados++;
                AñadirProgreso("1", 1);
                break;

            case 2:
                AñadirProgreso("2", 1);
                break;

            case 3:
                AñadirProgreso("3", 1);
                break;

            default:
            
                break;
        }
    }
  
    #endregion
}

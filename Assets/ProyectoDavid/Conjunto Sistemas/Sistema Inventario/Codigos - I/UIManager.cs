using UnityEngine;
public class UIManager : Singleton<UIManager>
{
    [Header("Paneles")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelMisiones;
    [SerializeField] private GameObject panelMisionesPersonaje;

    #region Paneles
    public void AbrirCerrarPanelStats()
    {
        panelStats.SetActive(!panelStats.activeSelf);
    }

    public void AbrirCerrarPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }
    public void AbrirCerrarPanelMisiones()
    {
        panelMisiones.SetActive(!panelMisiones.activeSelf);
    }
    public void AbrirCerrarPanelMisionesPersonaje()
    {
        panelMisionesPersonaje.SetActive(!panelMisionesPersonaje.activeSelf);
    }

    #endregion

}

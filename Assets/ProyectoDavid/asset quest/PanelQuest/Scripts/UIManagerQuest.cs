using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerQuest : MonoBehaviour
{
    [SerializeField] private GameObject _panelInspectorQuests;
    [SerializeField] private GameObject _panelPersonajeQuests;


    #region Abrir/Cerrar Paneles
    //Estos metodos funcionan para abrir y cerrar los paneles.
    public void AbrirCerrarPanelInspectorQuests()
    {
        _panelInspectorQuests.SetActive(!_panelInspectorQuests.activeSelf);  
    }
    public void AbrirCerrarPanelPersonajeQuests()
    {
        _panelPersonajeQuests.SetActive(!_panelPersonajeQuests.activeSelf);
    }
    #endregion

 
}

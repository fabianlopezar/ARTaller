using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



public enum TiposDeInteracion
{
    Click,
    Usar,
    Equipar,
    Remover
}
public class InventarioSlot : MonoBehaviour
{
    [Header("Panel Inventario Descripcion")]
    public static Action<TiposDeInteracion, int> EventoSlotInteraccion;
    [SerializeField] private Image itemIcono;
    [SerializeField] private GameObject fondoCantidad;
    [SerializeField] private TextMeshProUGUI cantidadTMP;

  public int Index { get; set; }
    
    public void ActualizarSlot(InventarioItem item, int cantidad)
    {
        itemIcono.sprite = item.Icono;
        cantidadTMP.text = cantidad.ToString();
    }
    public void ActivarSlotUI(bool estado)
    {
        itemIcono.gameObject.SetActive(estado);
       fondoCantidad.gameObject.SetActive(estado);   
    }
    public void ClickSlot()
    {
        EventoSlotInteraccion?.Invoke(TiposDeInteracion.Click, Index);
    }
    private void SlotInteraccionRespuesta(TiposDeInteracion tipo,int index)
    {
        if(tipo == TiposDeInteracion.Click)
        {

        }
    }
    private void OnEnable()
    {
        InventarioSlot.EventoSlotInteraccion += SlotInteraccionRespuesta;
    }
    private void OnDisable()
    {
        InventarioSlot.EventoSlotInteraccion -= SlotInteraccionRespuesta;
    }
}
 
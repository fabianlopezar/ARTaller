using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventarioUI : Singleton<InventarioUI>
{
    [Header("Panel Inventario Descripcion")]
    [SerializeField] private GameObject panelInventarioDescripcion;
    [SerializeField] private Image itemIcono;
    [SerializeField] private TextMeshProUGUI itemNombre;
    [SerializeField] private TextMeshProUGUI itemDescripcion;

    [SerializeField] private InventarioSlot slotPrefab;
    [SerializeField] private Transform  contenedor;

    private List<InventarioSlot> slotsDisponibles = new List<InventarioSlot>();

    private void Start()
    {
        inicializarInventario();
    }
    private void inicializarInventario()
    {
        for (int i = 0; i < Inventario.Instance.NumeroDeSlots; i++)
        {
            InventarioSlot nuevoSlot=Instantiate(slotPrefab, contenedor);
            nuevoSlot.Index = i;
            slotsDisponibles.Add(nuevoSlot);
        }
    }
    public void DibujarItemEnInventario(InventarioItem itemPorAñadir,int cantidad, int itemIndex)
    {
        InventarioSlot slot = slotsDisponibles[itemIndex];
        if (itemPorAñadir != null)
        {
            slot.ActivarSlotUI(true);
            slot.ActualizarSlot(itemPorAñadir,cantidad);
        }
        else
        {
            slot.ActivarSlotUI(false);
        }
    }
    private void ActualizarInventarioDescripcion(int index) 
    {
        if (Inventario.Instance.ItemsInventario[index] != null)
        {
            itemIcono.sprite = Inventario.Instance.ItemsInventario[index].Icono;
            itemNombre.text = Inventario.Instance.ItemsInventario[index].Nombre;
            itemDescripcion.text = Inventario.Instance.ItemsInventario[index].Descripcion;
            panelInventarioDescripcion.SetActive(true);
        }
        else
        {
            panelInventarioDescripcion.SetActive(false);
        }
    }
    private void SlotInteraccionRespuesta(TiposDeInteracion tipo, int index)
    {
        if (tipo == TiposDeInteracion.Click)
        {
            ActualizarInventarioDescripcion(index);
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
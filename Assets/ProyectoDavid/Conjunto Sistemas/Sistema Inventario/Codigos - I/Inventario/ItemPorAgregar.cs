using UnityEngine;
public class ItemPorAgregar : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private InventarioItem inventarioItemReferencia;
    [SerializeField] private int cantidadPorAgergar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventario.Instance.AñadirItem(inventarioItemReferencia, cantidadPorAgergar);
            Destroy(gameObject);
        }
    }
}

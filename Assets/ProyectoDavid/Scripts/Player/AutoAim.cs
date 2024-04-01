using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    //public float offset;
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            AutoApuntado();
        }
    }

    public void AutoApuntado()
    {
        // Encontrar todos los objetivos con el tag "Enemy"
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        // Si no hay objetivos, salir del método
        if (targets.Length == 0) return;

        // Asignar el primer objetivo como el objetivo más cercano por defecto
        GameObject closestTarget = targets[0];
        float closestDistance = Vector3.Distance(transform.position, closestTarget.transform.position);

        // Recorrer todos los objetivos y elegir el más cercano
        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestTarget = target;
                closestDistance = distance;
            }
        }

        // Calcular la dirección hacia el objetivo más cercano
        Vector2 direction = closestTarget.transform.position - transform.position;
        direction.Normalize();

        // Obtener el ángulo entre la dirección y el eje y (arriba)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Girar el personaje hacia el ángulo calculado, al angulo le resto 90 para que logre apuntar con la flecha verde y no con la flecha roja.
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}

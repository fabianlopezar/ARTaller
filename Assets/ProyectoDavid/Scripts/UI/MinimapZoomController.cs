using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapZoomController : MonoBehaviour
{
    public Camera minimapCamera;
    public float zoomSpeed = 0.5f;
    public float minZoom = 1.0f;
    public float maxZoom = 10.0f;

    private float initialTouchDistance;
    private float initialZoom;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            // Obtener el primer y segundo toque
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                // Si es el inicio del segundo toque, almacenar la distancia inicial entre ellos y el valor de zoom inicial
                initialTouchDistance = Vector2.Distance(touch1.position, touch2.position);
                initialZoom = minimapCamera.orthographicSize;
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                // Si los dedos se están moviendo, calcular la nueva distancia entre ellos
                float currentTouchDistance = Vector2.Distance(touch1.position, touch2.position);

                // Calcular el cambio en la distancia entre los dedos y usarlo para ajustar el zoom
                float zoomChange = (currentTouchDistance - initialTouchDistance) * zoomSpeed;

                // Calcular el nuevo valor de zoom
                float newZoom = initialZoom - zoomChange;

                // Limitar el valor del zoom dentro del rango permitido
                newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

                // Aplicar el nuevo valor de zoom a la cámara del minimapa
                minimapCamera.orthographicSize = newZoom;
            }
        }
    }
}

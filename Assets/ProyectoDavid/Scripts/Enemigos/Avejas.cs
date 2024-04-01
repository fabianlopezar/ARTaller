using UnityEngine;
public class Avejas : MonoBehaviour
{
    public GameObject panal;
    public float radio = 10;
    public float angulo = 0;
    public float speed;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovimientoAbeja();
        }
    }
    public void MovimientoAbeja()
    {
        float pos_x = panal.transform.position.x + Mathf.Cos(angulo * Mathf.Deg2Rad) * radio;
        float pos_y = panal.transform.position.y + Mathf.Sin(angulo * Mathf.Deg2Rad) * radio;
        transform.position = new Vector2(pos_x, pos_y);
        angulo = angulo + speed + Time.deltaTime;
    }
}

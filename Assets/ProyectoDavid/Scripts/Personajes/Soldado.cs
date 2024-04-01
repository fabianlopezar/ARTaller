using UnityEngine;
public class Soldado : MonoBehaviour
{
    public float speed;
    public bool moveright;

    private void FixedUpdate()
    {
        if (moveright)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }
}

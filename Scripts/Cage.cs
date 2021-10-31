
using UnityEngine;

public class Cage : MonoBehaviour // класс для изчезновения препятсвий после того как они прошли все поле
{
    private void OnCollisionEnter2D(Collision2D other)// метод при соприкосновении с препятствием
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle")) // если соприкоснулось со слоем obstacle
        {
            Destroy(gameObject); // уничтожения репятствия
        } 
    }
}

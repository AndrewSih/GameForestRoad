
using UnityEngine;
using Photon.Pun;


public class PlayerControlls : MonoBehaviour // классс управления игроком
{
    private Rigidbody2D _rb;                  // ссылка на компонент Rigidbody 
    [SerializeField] private float speed;     // поле движение влево и вправо
    [SerializeField] private float jumpForce; // сила разгона
    private Vector2 _direction;               // кординаты игрока
    [SerializeField] private float maxSpeed;  // максимальная скорость разгона
    private PhotonView photonview;            // ссылка на компонент photonview
    public float normalSpeed = 4f;            // скорость движениея по сторонам
    public GameObject canvas;                 // ссылка на канвас на котором кнопки
   

    void Start()
    {
        photonview = GetComponent<PhotonView>(); // получаем компонент PhotonView
        _rb = GetComponent<Rigidbody2D>();       // получаем компонент RigidBody
        if (!photonview.IsMine)                  // условие, если не твой игрок
        {
            canvas.SetActive(false);             // отключаем его канвас с управлением
        }
    }
    private void FixedUpdate()
    {
        if (photonview.IsMine)                                      // если игрок твой
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);      // движение влево и вправо
            if (_rb.velocity.y >= maxSpeed)                         // если движение по Y больше либо равно максимальной скорости
            {
                _rb.velocity = new Vector2(_direction.x, maxSpeed); // ограничивает набор скорости
            }
           /* if (_rb.velocity.y < 0)
            { 
                _rb.velocity = new Vector2(_rb.velocity.x, 0);  // условие чтобы машинка оставалась на тоже месте после разгона,
                                                                 // и не съезжала в низ, если нравится то раскоментируй 
            }*/
        }
       
    }
    public void OnLeftButtonDown() // метод для нажатия левой нопки
    {
        if (speed >= 0f)           // если скорость больше либо равно 0
        {
            speed = -normalSpeed;  // к скорости присваеваем нормальную скорость с минусом, чтобы поменять движение
        }
    }
    public void OnRightButtonDown() // метод нажатия правой кнопки
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }
    public void OnButtonUp() // метод если кнопка скорости отпущена
    {
        speed = 0f;
    }
     public void Jump() // метод разгона машинки вверх 
        {

        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
 
    public void PressPause() // если нажали на кнопку паузы
    {
        Camera.main.GetComponent<CanvasScript>().Pause(); // активировали метод Pause, который находится в компоненте камеры, в скрипте canvasscript
    }


}

    

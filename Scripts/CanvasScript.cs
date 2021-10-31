
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    void Start()
    {
        pauseCanvas.SetActive(false);
    }
    

    public void ExitButton() // метод выхода из приложения
    {
        Application.Quit();
    }
    
    public void PlayButton() //метод возобновления игры по нажатию кнопки продолжить
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
       
    }
    public void Pause() //метод постановки игры на паузу
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

}

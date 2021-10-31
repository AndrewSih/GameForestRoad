
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    void Start()
    {
        pauseCanvas.SetActive(false);
    }
    

    public void ExitButton() // ����� ������ �� ����������
    {
        Application.Quit();
    }
    
    public void PlayButton() //����� ������������� ���� �� ������� ������ ����������
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
       
    }
    public void Pause() //����� ���������� ���� �� �����
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

}

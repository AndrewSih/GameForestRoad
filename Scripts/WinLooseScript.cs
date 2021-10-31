
using UnityEngine;
using Photon.Pun;

public class WinLooseScript : MonoBehaviour //класс включающий скрипты winner и looser
{
    public GameObject winCanvas; // поле дл€ канваса победител€
    public GameObject looseCanvas;// поле дл€ канваса проигравшего
    private PhotonView photonview; // ссылка на компонент фотона 
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>(); // получаем компонент фотон 
        if (!photonview.IsMine)// условие. если не мой игрок
        {
            winCanvas.SetActive(false); // выключить канвасы
            looseCanvas.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D win) // метод, когда пересекает финишную линию
    {
        if (win.gameObject.tag == "Finish") // если столкнулс€ с объектом с тэгом финиш
        {
            if (photonview.IsMine)  // если игрок мой
            {
                winCanvas.SetActive(true); // включить канвас победител€
                Time.timeScale = 0.01f; // приостановить врем€ до 0,01 сек
            }
            else //если условие не выполн€етс€ 
            {
                looseCanvas.SetActive(true); // включить канвас проигравшего
                Time.timeScale = 0.01f;
            }
        }
    }
    public void CanvasButtonExit() // метод кнопки выхода
    {
        Application.Quit();
    }
    public void CanvasButtonReset() // метод кнопки перезапуска игры 
    {
        GameObject.Find("SpawnPlayer").GetComponent<spawn>().Leave(); // находим игровой объект —паунѕлеер 
                                                                       // в нем находим компонент спаун ( скрипт) и вызываем метод Leave
    }
}

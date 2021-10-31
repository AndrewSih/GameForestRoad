using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MenuManager : MonoBehaviourPunCallbacks // класс создани€ комнаты и подключени€ к ней
{
    public InputField createInput; // поле дл€ ввода имени сервера преред созданием
    public InputField joinInput; // поле дл€ ввода имени сервера дл€ подключение к существующему
    void Start()
    {
        Time.timeScale = 1; // снимаем с паузы
    }

    public void CreateRoom() // создание комнаты
    {
        RoomOptions roomOptions = new RoomOptions(); //объект комната
        roomOptions.MaxPlayers = 2; // максимальное количество игроков 2
        PhotonNetwork.CreateRoom(createInput.text, roomOptions); // создаем комнату использу€ введенное им€ сервера
    }

    public void JoinRoom() // метод подключени€ к комнате
    {
        PhotonNetwork.JoinRoom(joinInput.text); // подключаемс€ к уже кем-то созданной комнате после ввода имени сервера
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene"); // переход на игровую сцену
    }
 
}
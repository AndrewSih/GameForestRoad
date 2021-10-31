
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class spawn : MonoBehaviourPunCallbacks // класс для появления игроков на игровом поле
{
   
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) // если игрок мастер клиент, то есть создал сервер
        {
            Vector2 position1 = new Vector2(-4.4f, -0.72f); // кординаты пояления игрока 1
            PhotonNetwork.Instantiate("player1", position1, Quaternion.identity); // появления игрока 1 
        }
        else // если он не мастер клиент
        { 
            Vector2 position2 = new Vector2(-6f, -3f); // координаты пояления игрока 2
            PhotonNetwork.Instantiate("player2", position2, Quaternion.identity); // поялвения игрока 2
        }
    }

    public void Leave() // метод для выхода из игры ( из комнаты в лобби)
    {
        SceneManager.LoadScene(1); // запускаем сцену 1
        PhotonNetwork.LeaveRoom();// выходим из комнаты с игрой, но не отключаемся от сервера

    }
    public override void OnLeftRoom() 
    {

        SceneManager.LoadScene(1);
    }
}

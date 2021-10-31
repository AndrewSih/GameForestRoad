using Photon.Pun;
using UnityEngine.SceneManagement;

public class Connect : MonoBehaviourPunCallbacks // класс подключения к серверу фотон
{
   
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // используем настройки стандартные
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainManu"); // переходим на сцену ввода имени сервера
    }
}

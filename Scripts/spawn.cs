
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class spawn : MonoBehaviourPunCallbacks // ����� ��� ��������� ������� �� ������� ����
{
   
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) // ���� ����� ������ ������, �� ���� ������ ������
        {
            Vector2 position1 = new Vector2(-4.4f, -0.72f); // ��������� �������� ������ 1
            PhotonNetwork.Instantiate("player1", position1, Quaternion.identity); // ��������� ������ 1 
        }
        else // ���� �� �� ������ ������
        { 
            Vector2 position2 = new Vector2(-6f, -3f); // ���������� �������� ������ 2
            PhotonNetwork.Instantiate("player2", position2, Quaternion.identity); // ��������� ������ 2
        }
    }

    public void Leave() // ����� ��� ������ �� ���� ( �� ������� � �����)
    {
        SceneManager.LoadScene(1); // ��������� ����� 1
        PhotonNetwork.LeaveRoom();// ������� �� ������� � �����, �� �� ����������� �� �������

    }
    public override void OnLeftRoom() 
    {

        SceneManager.LoadScene(1);
    }
}

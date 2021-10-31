
using UnityEngine;
using Photon.Pun;

public class WinLooseScript : MonoBehaviour //����� ���������� ������� winner � looser
{
    public GameObject winCanvas; // ���� ��� ������� ����������
    public GameObject looseCanvas;// ���� ��� ������� ������������
    private PhotonView photonview; // ������ �� ��������� ������ 
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>(); // �������� ��������� ����� 
        if (!photonview.IsMine)// �������. ���� �� ��� �����
        {
            winCanvas.SetActive(false); // ��������� �������
            looseCanvas.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D win) // �����, ����� ���������� �������� �����
    {
        if (win.gameObject.tag == "Finish") // ���� ���������� � �������� � ����� �����
        {
            if (photonview.IsMine)  // ���� ����� ���
            {
                winCanvas.SetActive(true); // �������� ������ ����������
                Time.timeScale = 0.01f; // ������������� ����� �� 0,01 ���
            }
            else //���� ������� �� ����������� 
            {
                looseCanvas.SetActive(true); // �������� ������ ������������
                Time.timeScale = 0.01f;
            }
        }
    }
    public void CanvasButtonExit() // ����� ������ ������
    {
        Application.Quit();
    }
    public void CanvasButtonReset() // ����� ������ ����������� ���� 
    {
        GameObject.Find("SpawnPlayer").GetComponent<spawn>().Leave(); // ������� ������� ������ ���������� 
                                                                       // � ��� ������� ��������� ����� ( ������) � �������� ����� Leave
    }
}

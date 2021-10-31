
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviourPunCallbacks //класс для появления препятствий на игровом поле
{
    [SerializeField] private float spawnTime;           // поле где задаем время появления препятствий
    [SerializeField] private GameObject wideCage;       // поля для бревен
    [SerializeField] private GameObject cage;           // поле для камней

    private int count;                                  // количество препятствий
    void Start()
    {
     
        InvokeRepeating("Spawn", 0, spawnTime); // после старта, без задержки будем выполнять 
                                                // метод spawn с интервалом spawnTime  
    }

    [System.Obsolete]
    private void Spawn()
    {
        count = Random.Range(1, 6); 
        if (count == 5)
        {
            PhotonNetwork.InstantiateSceneObject("wideCage", new Vector3(Random.Range(-7.4f, 10.5f), 26f, 0f), Quaternion.identity);
            // создаем объекты сцены - бревна, которые синхранизируются на всех устройствах
        }
        else
        {
            PhotonNetwork.InstantiateSceneObject("cage", new Vector3(Random.Range(-8.3f, 10.6f), 26f, 0f), Quaternion.identity);
            //создаем камни 
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnEnemyManager : MonoBehaviourPunCallbacks
{
    public GameObject EnemyPrefab;
    public Transform[] spawnPositionsEnemies;
    private List<Vector3> PositionsEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Pun Callbacks
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount==2)
            {

                for (int i = 0; i < spawnPositionsEnemies.Length; i++)
                {
                    Vector3 enemPositi = spawnPositionsEnemies[i].position;
                    //GameObject enemyGameobject = Instantiate(EnemiesPrefab, enemPositi, Quaternion.identity);
                    GameObject enemyGameobject = PhotonNetwork.Instantiate(EnemyPrefab.name, enemPositi, Quaternion.identity);
                    enemyGameobject.transform.parent = spawnPositionsEnemies[i];
                    // PositionsEnemies.Add(enemPositi);
                }
            }
            else
            {
                Debug.Log("Solo hay un jugador");
            }
             //foreach (Vector3 aPart in PositionsEnemies)
            // {
              //  PhotonNetwork.Instantiate(EnemyPrefab.name, aPart, Quaternion.identity);
                //   Console.WriteLine(aPart);
                // Instantiate(EnemiesPrefab, aPart, Quaternion.identity);
             //}   
            
            // Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");
            // Create our player object when we've joined the room
            //PhotonNetwork.Instantiate(EnemyPrefab.name, new Vector3(0, 3.0f, 0), Quaternion.identity);

        }

    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class SpawnManager : MonoBehaviourPunCallbacks
{

    public GameObject[] playerPrefabs;
    public Transform[] spawnPositions;
    public GameObject EnemyPrefab;
    public Transform[] spawnPositionsEnemies;
    //public Transform[] spawnPositionsEnemies;

    // public GameObject EnemiesPrefab;

    public GameObject battleArenaGameobject;
    //private List<Vector3> PositionsEnemies;
    public enum RaiseEventCodes
    {
        PlayerSpawnEventCode = 0
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }




    #region Photon Callback Methods
    void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == (byte)RaiseEventCodes.PlayerSpawnEventCode)
        {

            object[] data = (object[])photonEvent.CustomData;
            Vector3 receivedPosition = (Vector3)data[0];
            Quaternion receivedRotation = (Quaternion)data[1];
            int receivedPlayerSelectionData = (int)data[3];

            GameObject player = Instantiate(playerPrefabs[receivedPlayerSelectionData], receivedPosition + battleArenaGameobject.transform.position, receivedRotation);
            PhotonView _photonView = player.GetComponent<PhotonView>();
            _photonView.ViewID = (int)data[2];


        }
    }



    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
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
            /*  object playerSelectionNumber;
              if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerARSpinnerTopGame.PLAYER_SELECTION_NUMBER, out playerSelectionNumber))
              {
                  Debug.Log("Player selection number is "+ (int)playerSelectionNumber);

                  int randomSpawnPoint = Random.Range(0, spawnPositions.Length-1);
                  Vector3 instantiatePosition = spawnPositions[randomSpawnPoint].position;


                  PhotonNetwork.Instantiate(playerPrefabs[(int)playerSelectionNumber].name, instantiatePosition, Quaternion.identity);

              }*/
            SpawnPlayer();


        }



    }
    #endregion


    #region Private Methods
    private void SpawnPlayer()
    {
        object playerSelectionNumber;
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerARSpinnerTopGame.PLAYER_SELECTION_NUMBER, out playerSelectionNumber))
        {
            Debug.Log("Player selection number is " + (int)playerSelectionNumber);

            int randomSpawnPoint = Random.Range(0, spawnPositions.Length - 1);
            Vector3 instantiatePosition = spawnPositions[randomSpawnPoint].position;
            GameObject playerGameobject = Instantiate(playerPrefabs[(int)playerSelectionNumber], instantiatePosition, Quaternion.identity);
            playerGameobject.transform.parent=spawnPositions[randomSpawnPoint];

         //   for (int i = 0; i < spawnPositionsEnemies.Length; i++)
         //{
         //   Vector3 enemPositi = spawnPositionsEnemies[i].position;
         //   GameObject enemyGameobject = Instantiate(EnemiesPrefab, enemPositi, Quaternion.identity);

            // PositionsEnemies.Add(enemPositi);

            // }
            // foreach (Vector3 aPart in PositionsEnemies)
            // {
            //   Console.WriteLine(aPart);
            // Instantiate(EnemiesPrefab, aPart, Quaternion.identity);
            // }            

            PhotonView _photonView = playerGameobject.GetComponent<PhotonView>();

            if (PhotonNetwork.AllocateViewID(_photonView))
            {
                object[] data = new object[]
                {

                    playerGameobject.transform.position- battleArenaGameobject.transform.position, playerGameobject.transform.rotation, _photonView.ViewID, playerSelectionNumber
                };


                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others,
                    CachingOption = EventCaching.AddToRoomCache

                };


                SendOptions sendOptions = new SendOptions
                {
                    Reliability = true
                };

                //Raise Events!
                PhotonNetwork.RaiseEvent((byte)RaiseEventCodes.PlayerSpawnEventCode, data, raiseEventOptions, sendOptions);


            }
            else
            {

                Debug.Log("Failed to allocate a viewID");
                Destroy(playerGameobject);
            }



        }
    }



    #endregion




}

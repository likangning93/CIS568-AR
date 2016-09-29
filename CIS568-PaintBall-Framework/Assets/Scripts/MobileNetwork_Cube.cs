﻿using UnityEngine;

public class MobileNetwork_Cube : Photon.PunBehaviour
{
    // TODO-1.b: write any functions needed to establish connection
    //   and join a room. Joining a random room will do for now if you are testing
    //   it yourself. But you can also list the rooms or require player to enter
    //   the room name in case there are more people playing
    //   your game - though it is not required for the assignment.

    string roomName;


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        roomName = PhotonNetwork.room.name;
        GameObject cube = PhotonNetwork.Instantiate("PhoneCube", new Vector3(0, 0, 0), Quaternion.identity, 0);
        GetComponent<GyroController>().ControlledObject = cube;
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        GUILayout.Label("Room Name: " + roomName);
    }
}

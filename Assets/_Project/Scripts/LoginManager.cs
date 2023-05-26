using Photon.Pun;
using TMPro;
using UnityEngine;

public class LoginManager : MonoBehaviourPunCallbacks {

    public TMP_InputField playerNameInput;

    #region UI Callback Methods
    public void ConnectAnonymously() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToPhotonServer() {
        if (playerNameInput != null) {
            PhotonNetwork.NickName = playerNameInput.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion

    #region Photon Callback Methods
    public override void OnConnected() {
        Debug.Log("[OnConnected] The server is available!");
    }

    public override void OnConnectedToMaster() {
        Debug.Log("[OnConnectedToMaster] Connected to master server with name: " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("Scene01");
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[System.Serializable]
public class ToggleEvent: UnityEvent<bool> { }

public class NetworkController : NetworkBehaviour {
	[SerializeField]ToggleEvent onToggleShared;
	[SerializeField]ToggleEvent onToggleLocal;
	[SerializeField]ToggleEvent onToggleRemote;
	[SerializeField]float respawnTime = 5.0f;

    static List<NetworkController> players = new List<NetworkController>();

    GameObject mainCamera;

    [ServerCallback]
    void OnEnable()
    {
        if (!players.Contains(this))
            players.Add(this);
    }

    [ServerCallback]
    void OnDisable()
    {
        if (players.Contains(this))
            players.Remove(this);
    }

    // Use this for initialization
    void Start () {
		mainCamera = Camera.main.gameObject;
		EnableDrone();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [Server]
    public void disablePlayers() {
        for (int i = 0; i < players.Count; i++)
            players[i].RpcdisablePlayer();
    }

    [ClientRpc]
    public void RpcdisablePlayer() {
        DisableDrone();
    }

	void EnableDrone ()
	{
		if (isLocalPlayer) {
			mainCamera.SetActive (false);
		}

		onToggleShared.Invoke(true);
		if (isLocalPlayer) {
			onToggleLocal.Invoke (true);
		} else {
			onToggleRemote.Invoke(true);
		}
	}

	void DisableDrone ()
	{
		if (isLocalPlayer) {
			mainCamera.SetActive (true);
		}

		onToggleShared.Invoke (false);

		if (isLocalPlayer) {
			onToggleLocal.Invoke (false);
		} else {
			onToggleRemote.Invoke (false);
		}
	}
}

using UnityEngine;
using UnityEngine.Networking;

public class CustomNetMan : NetworkBehaviour {
    //[SerializeField]
    string ipAddress;
	// Use this for initialization
	void Start () {
        NetworkManager.singleton.networkAddress = ipAddress;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

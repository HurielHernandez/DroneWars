using UnityEngine;
using UnityEngine.Networking;

public class CheckpointManager : NetworkBehaviour {
    private GameObject checkpointsHolder;
    private AudioSource checkpointSound;
    private GameObject[] checkpoints;
    private int checkpointIndex;
    private int laps;

	// Use this for initialization
	void Start () {
        if(isLocalPlayer)
        {
            laps = 0;
            checkpointIndex = 0;
            checkpointsHolder = GameObject.Find("checkpoints");
            checkpointSound = checkpointsHolder.GetComponent<AudioSource>();
            checkpoints = new GameObject[checkpointsHolder.transform.childCount];

            for(int i = 0; i < checkpointsHolder.transform.childCount; i++)
            {
                GameObject tmp = checkpointsHolder.transform.GetChild(i).gameObject;
                if(tmp.CompareTag("checkpoint"))
                {
                    checkpoints[i] = tmp;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other) {
        if(isLocalPlayer) {
            if(other.CompareTag("checkpoint")) {
                other.gameObject.SetActive(false);
                checkpointIndex++;
                if (checkpointIndex >= (checkpoints.Length - 1))
                {
                    checkpointIndex = checkpointIndex % (checkpoints.Length - 1);
                    laps++;
                    if(laps == 3) {
                        CmdEndGame();
                        return;
                    }
                }
                checkpoints[checkpointIndex].gameObject.SetActive(true);
            }
        }
    }

    [Command]
    public void CmdEndGame() {
        NetworkController nc = gameObject.GetComponentInParent<NetworkController>();
        nc.disablePlayers();
    }
}

using UnityEngine;
using UnityEngine.Networking;

public class CheckpointManager : NetworkBehaviour {
    /*
	public GameObject checkpoint1;
	public GameObject checkpoint2;
	public GameObject checkpoint3;
	public GameObject checkpoint4;
	public GameObject checkpoint5;
	public GameObject checkpoint6;
    */

    private GameObject checkpointsHolder;
    private AudioSource checkpointSound;
    private GameObject[] checkpoints;
    private int checkpointIndex;

	// Use this for initialization
	void Start () {
        /*
		checkpoint1 = GameObject.Find("Checkpoint1");
		checkpoint2 = GameObject.Find("Checkpoint2");
		checkpoint3 = GameObject.Find("Checkpoint3");
		checkpoint4 = GameObject.Find("Checkpoint4");
		checkpoint5 = GameObject.Find("Checkpoint5");
		checkpoint6 = GameObject.Find("Checkpoint6");

		checkpoint2.SetActive(false);
		checkpoint3.SetActive(false);
		checkpoint4.SetActive(false);
		checkpoint5.SetActive(false);
		checkpoint6.SetActive(false);
        */
        if(isLocalPlayer)
        {
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

    public void OnTriggerEnter(Collider other)
    {
        if(isLocalPlayer) {
            if(other.CompareTag("checkpoint"))
            {
                other.gameObject.SetActive(false);
                checkpointIndex++;
                if (checkpointIndex >= (checkpoints.Length - 1))
                {
                    checkpointIndex = checkpointIndex % (checkpoints.Length - 1);
                }
                checkpoints[checkpointIndex].gameObject.SetActive(true);
            }
        }
    }

    /*
    public void ShowNextCheckpoint (int number)
	{
		switch(number)
		{
			case 1:
				checkpoint1.SetActive(false);
				checkpoint2.SetActive(true);
				print("CASE1");
				break;
			case 2:
				checkpoint2.SetActive(false);
				checkpoint3.SetActive(true);
				break;
			case 3:
				checkpoint3.SetActive(false);
				checkpoint4.SetActive(true);
				break;
			case 4:
				checkpoint4.SetActive(false);
				checkpoint5.SetActive(true);
				break;
			case 5:
				checkpoint5.SetActive(false);
				checkpoint6.SetActive(true);
				break;
		}
	}
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

	 GameObject checkpoint1;
	 GameObject checkpoint2;
	 GameObject checkpoint3;
	 GameObject checkpoint4;
	 GameObject checkpoint5;
	 GameObject checkpoint6;
	 GameObject checkpoint7;
	 GameObject checkpoint8;
	 GameObject checkpoint9;
	 GameObject checkpoint10;
	 GameObject checkpoint11;
	 GameObject checkpoint12;
	 GameObject checkpoint13;
	 GameObject checkpoint14;
	 GameObject checkpoint15;
	 GameObject checkpoint16;
	 GameObject checkpoint17;
	 GameObject checkpoint18;
	 GameObject checkpoint19;
	 GameObject checkpoint20;

	// Use this for initialization
	void Start () {
		checkpoint1 = GameObject.Find("Checkpoint1");
		checkpoint2 = GameObject.Find("Checkpoint2");
		checkpoint3 = GameObject.Find("Checkpoint3");
		checkpoint4 = GameObject.Find("Checkpoint4");
		checkpoint5 = GameObject.Find("Checkpoint5");
		checkpoint6 = GameObject.Find("Checkpoint6");
		checkpoint7 = GameObject.Find("Checkpoint7");
		checkpoint8 = GameObject.Find("Checkpoint8");
		checkpoint9 = GameObject.Find("Checkpoint9");
		checkpoint10 = GameObject.Find("Checkpoint10");
		checkpoint11 = GameObject.Find("Checkpoint11");
		checkpoint12 = GameObject.Find("Checkpoint12");
		checkpoint13 = GameObject.Find("Checkpoint13");
		checkpoint14 = GameObject.Find("Checkpoint14");
		checkpoint15 = GameObject.Find("Checkpoint15");
		checkpoint16 = GameObject.Find("Checkpoint16");
		checkpoint17 = GameObject.Find("Checkpoint17");
		checkpoint18 = GameObject.Find("Checkpoint18");
		checkpoint19 = GameObject.Find("Checkpoint19");
		checkpoint20 = GameObject.Find("Checkpoint20");



		checkpoint2.SetActive(false);
		checkpoint3.SetActive(false);
		checkpoint4.SetActive(false);
		checkpoint5.SetActive(false);
		checkpoint6.SetActive(false);
		checkpoint7.SetActive(false);
		checkpoint8.SetActive(false);
		checkpoint9.SetActive(false);
		checkpoint10.SetActive(false);
		checkpoint11.SetActive(false);
		checkpoint12.SetActive(false);
		checkpoint13.SetActive(false);
		checkpoint14.SetActive(false);
		checkpoint15.SetActive(false);
		checkpoint16.SetActive(false);
		checkpoint17.SetActive(false);
		checkpoint18.SetActive(false);
		checkpoint19.SetActive(false);
		checkpoint20.SetActive(false);



	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowNextCheckpoint (int number)
	{
		switch(number)
		{
			case 1:
				checkpoint1.SetActive(false);
				checkpoint2.SetActive(true);
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
			case 6:
				checkpoint6.SetActive(false);
				checkpoint7.SetActive(true);
				break;
			case 7:
				checkpoint7.SetActive(false);
				checkpoint8.SetActive(true);
				break;
			case 8:
				checkpoint8.SetActive(false);
				checkpoint9.SetActive(true);
				break;
			case 9:
				checkpoint9.SetActive(false);
				checkpoint10.SetActive(true);
				break;
			case 10:
				checkpoint10.SetActive(false);
				checkpoint11.SetActive(true);
				break;
			case 11:
				checkpoint11.SetActive(false);
				checkpoint12.SetActive(true);
				break;
			case 12:
				checkpoint12.SetActive(false);
				checkpoint13.SetActive(true);
				break;
			case 13:
				checkpoint13.SetActive(false);
				checkpoint14.SetActive(true);
				break;
			case 14:
				checkpoint14.SetActive(false);
				checkpoint15.SetActive(true);
				break;
			case 15:
				checkpoint15.SetActive(false);
				checkpoint16.SetActive(true);
				break;
			case 16:
				checkpoint16.SetActive(false);
				checkpoint17.SetActive(true);
				break;
			case 17:
				checkpoint17.SetActive(false);
				checkpoint18.SetActive(true);
				break;
			case 18:
				checkpoint18.SetActive(false);
				checkpoint19.SetActive(true);
				break;
			case 19:
				checkpoint19.SetActive(false);
				checkpoint20.SetActive(true);
				break;
			case 20:
				checkpoint20.SetActive(false);
				//checkpoint2.SetActive(true);
				break;
		}
	}
}

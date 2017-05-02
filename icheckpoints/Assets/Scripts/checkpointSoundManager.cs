using UnityEngine;

public class checkpointSoundManager : MonoBehaviour {

    public AudioSource checkpointSound;

    public void OnTriggerEnter(Collider other) {
        checkpointSound.Play();
    }
}

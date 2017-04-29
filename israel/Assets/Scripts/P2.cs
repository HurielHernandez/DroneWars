using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[System.Serializable]
public class ToogleEvent : UnityEvent<bool> { }

public class P2 : NetworkBehaviour
{
    [SerializeField] ToogleEvent onToogleShared;
    [SerializeField] ToogleEvent onToogleLocal;
    [SerializeField] ToogleEvent onToogleRemote;
    [SerializeField] float respawnTime = 5.0f;

    GameObject mainCamera;

    private void Start() {
        mainCamera = Camera.main.gameObject;
        EnablePlayer();
    }

    void DisablePlayer() {
        if(isLocalPlayer) {
            mainCamera.SetActive(true);
        }

        onToogleShared.Invoke(false);

        if (isLocalPlayer) {
            onToogleLocal.Invoke(false);
        } else {
            onToogleRemote.Invoke(false);
        }
    }

    void EnablePlayer() {
        if(isLocalPlayer) {
            mainCamera.SetActive(false);
        }

        onToogleShared.Invoke(true);

        if(isLocalPlayer) {
            onToogleLocal.Invoke(true);

        } else {
            onToogleRemote.Invoke(true);
        }
    }

    public void Die() {
        DisablePlayer();
        Invoke("Respawn", respawnTime);
    }

    void Respawn()
    {
        if(isLocalPlayer)
        {
            Transform spawn = NetworkManager.singleton.GetStartPosition();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
        }
        EnablePlayer();
    }
}

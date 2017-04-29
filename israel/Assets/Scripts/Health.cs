using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
    [SerializeField] int maxHealth = 3;

    P2 player;
    int health;

    private void Awake() {
        player = GetComponent<P2>();
    }

    [ServerCallback]        //code only runs in the server
    private void OnEnable() {
        health = maxHealth;
    }

    [Server]                //only server runs this
    public bool TakeDamage() {
        bool died = false;

        if(health <= 0) {
            return died;
        }

        health--;
        died = health <= 0;

        //process effects related to taking damage before returning
        RpcTakeDamage(died);

        return died;
    }

    [ClientRpc]
    void RpcTakeDamage(bool died)
    {
        //handle graphical stuff related to taking damage
        if(died) {
            player.Die();
        }
    }
}

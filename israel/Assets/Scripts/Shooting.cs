using UnityEngine;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour {
    [SerializeField] float shotCooldown = 0.3f;
    [SerializeField] Transform firePosition;
    [SerializeField] ShotEffectsManager shotEffects;

    float ellapsedTime;
    bool canShoot;

    private void Start()
    {
        //shotEffects.Initialize();

        if(isLocalPlayer) {
            canShoot = true;
            ellapsedTime = 1.0f;    //1.0 > 0.3
        }
    }

    private void Update() {
        if(! canShoot) {
            return;
        }
        ellapsedTime += Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && ellapsedTime > shotCooldown) {
            ellapsedTime = 0.0f;
            CmdFireShot(firePosition.position, firePosition.forward);
        }
    }

    [Command]   //this only happens in the server
    void CmdFireShot(Vector3 origin, Vector3 direction) {
        RaycastHit hit;

        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 50.0f, Color.red, 5.0f);   //for debugging purposes

        bool result = Physics.Raycast(ray, out hit, 50.0f);

        if(result) {
            Health enemy = hit.transform.GetComponent<Health>();

            if(enemy != null) {
                enemy.TakeDamage();
            }
        }

        //RpcProcessShotEffects(result, hit.point);
    }

    [ClientRpc]     //server tells all clients to perform this action
    void RpcProcessShotEffects(bool playImpact, Vector3 point) {
        shotEffects.PlayShotEffects();

        if(playImpact) {
            shotEffects.PlayImpactEffect(point);
        }
    }
}

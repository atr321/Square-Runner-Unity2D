using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Player player;
    private bool canShoot = true;
    private float range = 15;
    private float cooldown = 1.5f;
    private float angle;
    public GameObject projectile;
    public Transform shootingPosition;
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start() {
        this.audioSrc = this.GetComponent<AudioSource>();
        this.player = GameObject.FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update() {

    }


    void FixedUpdate() {


        this.handleRotation();
        this.handleShoot();
    }

    // *** SHOOTING *** //
    private void handleShoot() {
        float distance = Physics2D.Distance(this.player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>()).distance;

        if (distance <= this.range && this.canShoot) {
            this.shoot();
        }

    }


    private void shoot() {
        this.canShoot = false;
        StartCoroutine(this.resetShootCooldown());
        this.audioSrc.PlayOneShot(AudioManager.fire);
        Instantiate(this.projectile, this.transform.position, this.transform.rotation);

    }

    private IEnumerator resetShootCooldown() {
        yield return new WaitForSeconds(this.cooldown);
        this.canShoot = true;
    }

    private void handleRotation() {

        Vector3 target = this.player.transform.position;
        target.z = 0f;
        Vector3 objPos = this.transform.position;
        target.x = target.x - objPos.x;
        target.y = target.y - objPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


    }

}

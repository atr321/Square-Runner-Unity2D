using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    // Start is called before the first frame update

    private float speed = 15.13f;
    private Rigidbody2D rig;

    void Start() {
        this.rig = this.GetComponent<Rigidbody2D>();
        StartCoroutine(this.delayDestroy());
    }

    // Update is called once per frame
    void Update() {

    }


    void FixedUpdate() {
        this.rig.velocity = this.transform.right * this.speed;
    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            Player player = col.gameObject.GetComponent<Player>();
            player.takeDamage();
        }

        Destroy(this.gameObject);
    }


    private IEnumerator delayDestroy() {
        yield return new WaitForSeconds(13);
        if (this.gameObject != null)
            Destroy(this.gameObject);
    }
}

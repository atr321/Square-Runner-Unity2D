using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {


    [Header("Animation Parameters")]
    public float frameChanger = 0.03f;
    public float changeDistance = 0.4f;
    private int direction = 1;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start() {
        this.startPosition = this.transform.position;
        Random rand = new Random();
        float y = this.transform.position.y;
        float cd = this.changeDistance;
        float newY = Random.Range(y - cd, y + cd);
        this.transform.position = new Vector3(this.transform.position.x, newY, 0);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        this.handMadeAnimation();
    }

    private void handMadeAnimation() {
        float x = this.transform.position.x;
        float y = this.transform.position.y + (this.frameChanger * this.direction);
        float z = 0;
        this.transform.position = new Vector3(x, y, z);
  
        float distance = Mathf.Abs(Mathf.Abs(this.startPosition.y) - Mathf.Abs(this.transform.position.y));
        if (distance >= this.changeDistance) {

            this.direction *= -1;

        }
    }

    public void collect() {
        Destroy(this.gameObject);
    }
}

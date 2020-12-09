using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [Header("Movement")]
    public float movementSpeed = 4;
    [Space]
    [Header("Health")]
    [SerializeField] private int playerHp = 3;
    [SerializeField] private int maxHP = 6;
    private bool isAlive = true;
    [Space]
    [Header("UI Objects")]
    // public Slider hpBar;
    public Text emeraldText;
    public Text healthText;
    public GameObject trail;
    [Space]
    [Header("Emeralds")]
    [SerializeField] private int maxEmeralds = 20;


    //REFERENCES
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spr;
    private bool grounded;
    private int emeralds = 0;

    // Start is called before the first frame update
    void Start() {

        this.rig = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.spr = GetComponent<SpriteRenderer>();
        // this.hpBar.maxValue = playerHp;
    }

    void Update() {
        this.emeraldText.text = $"{this.emeralds}".PadLeft(3, ' ');
        this.healthText.text = $"{this.playerHp}".PadLeft(3, ' ');

        // Debug.Log(( Random.Range(0, 3) + "a meu amor ");
    }

    // Update is called once per frame
    void FixedUpdate() {
        // hpBar.value = playerHp;
        if (isAlive) {
            this.handleMovement();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Emerald" && isAlive) {
            this.collectEmerald(other.gameObject.GetComponent<Emerald>());
        }

        if (other.gameObject.tag == "Heart" && isAlive) {
            this.collectHeart(other.gameObject.GetComponent<Heart>());
        }

    }

    private void collectEmerald(Emerald emerald) {
        this.emeralds++;
        if (this.emeralds >= this.maxEmeralds) {
            // this.winGame();
            SceneManager.LoadScene(2);
        }
        emerald.collect();
    }
    private void collectHeart(Heart heart) {
        Debug.Log("sim");
        if (this.playerHp + 1 <= this.maxHP) {
            this.playerHp++;
            heart.collect();
        }

    }

    public void takeDamage() {
        playerHp -= 1;

        if (playerHp <= 0 && isAlive) {
            this.isAlive = false;
            this.anim.SetBool("sad", true);
            StartCoroutine(this.gameOver());
        }
    }

    private IEnumerator gameOver(){
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }


    private void handleMovement() {
        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        this.rig.velocity = new Vector2(movementSpeed * h, movementSpeed * y);
        if (h != 0 || y != 0) Instantiate(this.trail, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
    }

}

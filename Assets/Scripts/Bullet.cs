using MyColor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int bulletSpeed = 5;
    public int color = 2;

    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;

    private bool isSecondaryBullet = false;
    private Vector2 direction = Vector2.right;
    private bool ignoreFirstCollision = false;

    private Hashtable colorTable = new Hashtable() {
        { (int)Colors.Red, new Color32(255,0,0,255) },
        { (int)Colors.Yellow, new Color32(255,255,0,255) },
        { (int)Colors.Blue, new Color32(0,0,255,255) }
    };

    public Sprite RedSprite;
    public Sprite YellowSprite;
    public Sprite BlueSprite;
    private Hashtable spriteTable;

    // Start is called before the first frame update
    void Start() {
        _rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spriteTable = new Hashtable() {
            { (int)Colors.Red, RedSprite },
            { (int)Colors.Yellow, YellowSprite },
            { (int)Colors.Blue, BlueSprite }
        };
    }

    // Update is called once per frame
    void Update() {

        //transform.Translate(direction * bulletSpeed * Time.deltaTime);
        _rb2d.velocity = direction * bulletSpeed;
        //_spriteRenderer.color = (Color32)colorTable[color];
        _spriteRenderer.sprite = (Sprite)spriteTable[color];

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Disappear") {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log(isSecondaryBullet);
        if (collision.gameObject.tag == "Brick") {
            if (ignoreFirstCollision) {
                ignoreFirstCollision = false;
            } else {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Wall") {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }

    public bool GetSecondaryBullet() {
        return isSecondaryBullet;
    }
    public void SetSecondaryBullet(bool isSecondaryBullet) {
        this.isSecondaryBullet = isSecondaryBullet;
    }

    public Vector2 GetDirection() {
        return direction;
    }
    public void SetDirection(Vector2 direction) {
        this.direction = direction;
    }

    public void SetIgnoreFirstCollision(bool flag) {
        ignoreFirstCollision = flag;
    }
}

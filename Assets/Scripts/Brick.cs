using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MyColor;
using System.Collections;

public class Brick : MonoBehaviour {

    public int color = (int) Colors.Red;
    public float speed = 2;
    public GameObject bulletPrefab;

    //private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;
    private Vector2 direction = Vector2.left;
    private Hashtable colorTable = new Hashtable() {
        { (int)Colors.Red, new Color(255,0,0) },
        { (int)Colors.Yellow, new Color(255, 255, 0) },
        { (int)Colors.Blue, new Color(0,0,255) },
        { (int)Colors.Orange, new Color(255,165,0)},
        { (int)Colors.Purple, new Color(255,0,255) },
        { (int)Colors.Green, new Color(0,255,0) },
        { (int)Colors.Black, new Color(0,0,0)}
    };

    private HashSet<int> colorSet = new HashSet<int>() {
        (int)Colors.Orange,
        (int)Colors.Purple,
        (int)Colors.Green,
        (int)Colors.Black
    };

    public void SetDirection(Vector2 direction) {
        this.direction = direction;
    }

    void Start() {
        //_rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
        //_rb2d.velocity = direction * speed;
        _spriteRenderer.color = (Color)colorTable[color];
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Disappear") {
            Destroy(gameObject);
       }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            Debug.Log(collision.gameObject.GetComponent<Bullet>().color);
            Debug.Log("color = " + color);
            Bullet shutBullet = collision.gameObject.GetComponent<Bullet>();
            int shutColor = shutBullet.color;
            if (shutColor == color) {
                //Debug.Log("color = " + color);
                Destroy(gameObject);
                if (!shutBullet.GetSecondaryBullet()) {
                    CreateBullet(collision, shutColor, false);
                }
            } else if (colorSet.Contains(color) && colorTable.ContainsKey(color - shutColor) && shutColor != color - shutColor) {
                if (!shutBullet.GetSecondaryBullet()) {
                    CreateBullet(collision, shutColor, true);
                }
                color -= shutColor;
            }
        }
    }

    private void CreateBullet(Collision2D collision, int shotColor, bool flag) {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.localScale = transform.localScale;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.color = shotColor;
        bulletScript.SetDirection(Vector2.Reflect(direction.normalized, collision.contacts[0].normal));
        bulletScript.SetSecondaryBullet(true);
        bulletScript.SetIgnoreFirstCollision(flag);
    }
}

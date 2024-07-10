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

    public Sprite RedSprite;
    public Sprite YellowSprite;
    public Sprite BlueSprite;
    public Sprite OrangeSprite;
    public Sprite PurpleSprite;
    public Sprite GreenSprite;
    public Sprite BlackSprite;
    private Hashtable spriteTable;

    //private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;
    private Vector2 direction = Vector2.left;
    private Hashtable colorTable = new Hashtable() {
        { (int)Colors.Red, new Color32(255,0,0,255) },
        { (int)Colors.Yellow, new Color32(255,255,0,255) },
        { (int)Colors.Blue, new Color32(0,0,255,255) },
        { (int)Colors.Orange, new Color32(255,165,0,255)},
        { (int)Colors.Purple, new Color32(255,0,255,255) },
        { (int)Colors.Green, new Color32(0,255,0,255) },
        { (int)Colors.Black, new Color32(0,0,0,255)}
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

    public SpriteRenderer GetSpiriteRenderer() {
        return _spriteRenderer;
    }

    void Start() {
        //_rb2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log(_spriteRenderer.color);
        //_spriteRenderer.color = (Color32)colorTable[color];
        //Debug.Log(_spriteRenderer.color);
        //Debug.Log(111);

        spriteTable = new Hashtable() {
            { (int)Colors.Red, RedSprite },
            { (int)Colors.Yellow, YellowSprite },
            { (int)Colors.Blue, BlueSprite },
            { (int)Colors.Orange, OrangeSprite },
            { (int)Colors.Purple, PurpleSprite },
            { (int)Colors.Green, GreenSprite },
            { (int)Colors.Black, BlackSprite }
        };
        _spriteRenderer.sprite = (Sprite)spriteTable[color];
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
        //_rb2d.velocity = direction * speed;
        //_spriteRenderer.color = (Color32)colorTable[color];
        _spriteRenderer.sprite = (Sprite)spriteTable[color];
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Disappear") {
            Destroy(gameObject);
       }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            //Debug.Log(collision.gameObject.GetComponent<Bullet>().color);
            //Debug.Log("color = " + color);
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
        //Debug.Log(direction.normalized);
        //Debug.Log(collision.contacts[0].normal);
        //bulletScript.SetDirection(Vector2.Reflect(direction.normalized, collision.contacts[0].normal));
        //Debug.Log(bulletScript.GetDirection());
        //bulletScript.SetDirection(collision.contacts[0].normal);
        if (collision.contacts[0].normal.y > 0.173) {
            bulletScript.SetDirection(new Vector2(1, 1).normalized);
        } else if (collision.contacts[0].normal.y < -0.173) {
            bulletScript.SetDirection(new Vector2(1, -1).normalized);
        } else {
            bulletScript.SetDirection(new Vector2(1, 0));
        }
        
        bulletScript.SetSecondaryBullet(true);
        bulletScript.SetIgnoreFirstCollision(flag);
    }
}

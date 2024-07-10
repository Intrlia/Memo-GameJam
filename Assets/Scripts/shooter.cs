using MyColor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    //public GameObject bulletRed;
    //public GameObject bulletYellow;
    //public GameObject bulletBlue;

    public Sprite RedSprite;
    public Sprite YellowSprite;
    public Sprite BlueSprite;


    public GameObject bulletPrefab;
    public int count;
    //private GameObject currentBullet; // 当前使用的子弹
    private int currentColor;
    private Rigidbody2D _rigid;
    private SpriteRenderer _sprite;
    [SerializeField]public float speed = 3;
    public float fireRate = 0.1f;
    private float nextFire = 0.0f;
    private Hashtable colorTable = new Hashtable() {
        { (int)Colors.Red, new Color32(255,0,0,255) },
        { (int)Colors.Yellow, new Color32(255,255,0,255) },
        { (int)Colors.Blue, new Color32(0,0,255,255) }
    };

    private Hashtable spriteTable;




    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0.5f;
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        spriteTable = new Hashtable() {
            { (int)Colors.Red, RedSprite },
            { (int)Colors.Yellow, YellowSprite },
            { (int)Colors.Blue, BlueSprite }
        };
        currentColor = 2;
        //currentBullet = bullet;
    }

    // Update is called once per frame
    void Update()
    {
     
        float y = Input.GetAxis("Vertical");
        _rigid.velocity = new Vector2(0, y*speed);
        if (Input.GetMouseButtonDown(1)) // 1 表示右键
        {
            //// 根据当前子弹类型切换到下一个子弹类型
            //if (currentBullet == bulletRed)
            //{
            //    currentBullet=bulletYellow;
            //}
            //else if (currentBullet == bulletYellow)
            //{
            //    currentBullet=bulletBlue;
            //}
            //else if (currentBullet == bulletBlue)
            //{
            //    currentBullet=bulletRed; // 回到第一种子弹
            //}
            currentColor = (currentColor - 1) % 3 + 2;
        }

        _sprite.sprite = (Sprite)spriteTable[currentColor];


        if (Time.time > nextFire)
        {
            if (Input.GetMouseButton(0) && count > 0)
            { 
                //Debug.Log("currentColor:" + currentColor);
                //Debug.Log("currentColor:" + colorTable[currentColor]);
                GameObject bullet =  Instantiate(bulletPrefab, transform.position, transform.rotation);
                //bullet.GetComponent<SpriteRenderer>().color = (Color32)colorTable[currentColor];
                bullet.GetComponent<Bullet>().color = currentColor;
                //Debug.Log("currentColor:" + bullet.GetComponent<SpriteRenderer>().color);
                //currentColor = (currentColor - 1) % 3 + 2;
                nextFire = Time.time + fireRate;
                count--;
            }
        }

        if (count <= 0) {

            // 游戏结束
        }

        
    }
}


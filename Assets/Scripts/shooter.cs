using MyColor;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class shooter : MonoBehaviour
{
    public Sprite RedSprite;
    public Sprite YellowSprite;
    public Sprite BlueSprite;
    public AudioSource As;
    public GameObject Limit;
    public GameObject bulletPrefab;
    public int count;
    [SerializeField]public float speed = 4;

    private int currentColor;
    private SpriteRenderer _sprite;
    private TextMeshProUGUI textMesh;

    public float fireRate = 0.1f;
    private float nextFire = 0.0f;
    private Hashtable colorTable = new Hashtable() {
        { (int)Colors.Red, new Color32(255,0,0,255) },
        { (int)Colors.Yellow, new Color32(255,255,0,255) },
        { (int)Colors.Blue, new Color32(0,0,255,255) }
    };

    private Hashtable spriteTable;
    private OnButton onButton;

    private float downLimit;
    private float upLimit;




    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        spriteTable = new Hashtable() {
            { (int)Colors.Red, RedSprite },
            { (int)Colors.Yellow, YellowSprite },
            { (int)Colors.Blue, BlueSprite }
        };
        currentColor = 2;

        Vector3[] corners = new Vector3[4];
        RectTransform limitRect = Limit.GetComponent<RectTransform>();
        limitRect.GetWorldCorners(corners);
        downLimit = corners[0].y;
        upLimit = corners[1].y;

        onButton = GameObject.FindObjectOfType<OnButton>();

    }

    // Update is called once per frame
    void Update()
    {
     
        float y = Input.GetAxis("Vertical");
        transform.Translate(Math.Sign(y) * speed * Time.deltaTime * Vector2.up);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, downLimit, upLimit));


        if (Input.GetMouseButtonDown(1)) // 1 表示右键
        {
            currentColor = (currentColor - 1) % 3 + 2;
        }

        _sprite.sprite = (Sprite)spriteTable[currentColor];

        if (Time.time > nextFire)
        {
            //if (Input.GetMouseButton(0)) {
            //    Debug.Log(Input.GetMouseButton(0) + "-" + count + "-" + !onButton.GetIsHovering());
            //    Debug.Log(onButton);
            //}
                
            if (Input.GetMouseButton(0) && count > 0 && !onButton.GetIsHovering() && Time.timeScale > 0)
            { 
                GameObject bullet =  Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.GetComponent<Bullet>().color = currentColor;
                nextFire = Time.time + fireRate;
                As.Play();
                count--;
            }
        }

        if (count <= 0) {

            // 游戏结束
        }

        //TextDisplayer.Instance.DisplayMessage(count.ToString(), 30, Color.black, new Rect(transform.position.x, transform.position.y, 0, 0));
        if (textMesh != null)
            textMesh.text = count.ToString();

    }


}


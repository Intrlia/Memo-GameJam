using MyColor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    public GameObject _Brick;
    public float spawnRate = 2;
    private float timer = 0;
    public float spawnOffset = 4;
    private System.Random random;

    static int totalbricks = 0;
    public int bricknums = 99;

    private Hashtable colorTable = new Hashtable() {
        { 1, (int)Colors.Red},
        { 2, (int)Colors.Yellow},
        { 3, (int)Colors.Blue},
        { 4, (int)Colors.Orange},
        { 5, (int)Colors.Purple},
        { 6, (int)Colors.Green},
        { 7, (int)Colors.Black}
    };

    // Start is called before the first frame update
    void Start() {
        random = new System.Random();
        //SpawnBrick();
    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnBrick();
            timer = 0;
        }
        CheckWin();
    }

    void SpawnBrick() {
        int randomNumber;
        //GameObject Brick1 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y + spawnOffset, 0), transform.rotation);
        //randomNumber = random.Next(1, 8);
        //Brick1.GetComponent<Brick>().color = (int)colorTable[randomNumber];
        //Debug.Log(333);
        GameObject Brick2 = Instantiate(_Brick, new Vector3(transform.position.x, transform.position.y + spawnOffset / 2, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        //Debug.Log(randomNumber);
        //Debug.Log("color = " + Brick2.GetComponent<Brick>().color);
        Brick2.GetComponent<Brick>().color = (int)colorTable[randomNumber];
        //Debug.Log("color = " + Brick2.GetComponent<Brick>().color);
        //Debug.Log(222);

        GameObject Brick3 = Instantiate(_Brick, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        //Debug.Log(randomNumber);
        Brick3.GetComponent<Brick>().color = (int)colorTable[randomNumber];

        GameObject Brick4 = Instantiate(_Brick, new Vector3(transform.position.x, transform.position.y - spawnOffset / 2, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        //Debug.Log(randomNumber);
        Brick4.GetComponent<Brick>().color = (int)colorTable[randomNumber];

        //Debug.Log("----------------");
        //GameObject Brick5 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y - spawnOffset, 0), transform.rotation);
        //randomNumber = random.Next(1, 8);
        //Brick5.GetComponent<Brick>().color = (int)colorTable[randomNumber];
    }

    void CheckWin() {
        //Debug.Log("Remaining Brick Count: " + Brick.GetRemainingBrickCount());
        if (Brick.GetRemainingBrickCount() == 0 && totalbricks >= bricknums) {
            Debug.Log("ÄãÓ®À²£¡");
        }
    }
}

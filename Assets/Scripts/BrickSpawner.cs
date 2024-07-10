using MyColor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    public GameObject Brick;
    public float spawnRate = 2;
    private float timer = 0;
    public float spawnOffset = 4;
    private System.Random random;

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
        SpawnBrick();
    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnBrick();
            timer = 0;
        }

    }

    void SpawnBrick() {
        GameObject Brick1 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y + spawnOffset, 0), transform.rotation);
        int randomNumber = random.Next(1, 8);
        Brick1.GetComponent<Brick>().color = (int)colorTable[randomNumber];
        GameObject Brick2 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y + spawnOffset / 2, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        Brick2.GetComponent<Brick>().color = (int)colorTable[randomNumber];
        GameObject Brick3 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        Brick3.GetComponent<Brick>().color = (int)colorTable[randomNumber];
        GameObject Brick4 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y - spawnOffset / 2, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        Brick4.GetComponent<Brick>().color = (int)colorTable[randomNumber];
        GameObject Brick5 = Instantiate(Brick, new Vector3(transform.position.x, transform.position.y - spawnOffset, 0), transform.rotation);
        randomNumber = random.Next(1, 8);
        Brick5.GetComponent<Brick>().color = (int)colorTable[randomNumber];
    }
}

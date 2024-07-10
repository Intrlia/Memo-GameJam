using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeathDetect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Debug.Log(Time.timeScale);
            Time.timeScale = 0;
            //collision.gameObject.SetActive(false);
            //SceneManager.LoadScene("LostUI");
        }
    }
}

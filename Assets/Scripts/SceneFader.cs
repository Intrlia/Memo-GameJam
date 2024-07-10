using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {
    public float fadeSpeed = 12f;      // 淡入淡出速度
    public Color fadeColor = Color.black;  // 淡入淡出颜色 

    void Start() {
        Image image = GetComponent<Image>();
        image.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f);
        image.transform.SetAsLastSibling();
    }

    IEnumerator FadeIn() {
        Image image = GetComponent<Image>();
        image.raycastTarget = true;

        while (image.color.a < 1f) {
            float alpha = image.color.a + fadeSpeed * Time.deltaTime;
            image.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }

        image.raycastTarget = false;
    }

    IEnumerator FadeOut() {
        Image image = GetComponent<Image>();
        image.raycastTarget = true;

        while (image.color.a > 0f) {
            float alpha = image.color.a - fadeSpeed * Time.deltaTime;
            image.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            yield return null;
        }

        image.raycastTarget = false;
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
        StartCoroutine(FadeIn());
    }
}

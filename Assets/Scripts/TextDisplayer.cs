using UnityEngine;

public class TextDisplayer : MonoBehaviour {
    private static TextDisplayer instance;

    public static TextDisplayer Instance {
        get {
            if (instance == null) {
                // ����һ���µ�GameObject������TextDisplayer�ű�
                GameObject go = new GameObject("TextDisplayer");
                instance = go.AddComponent<TextDisplayer>();
            }
            return instance;
        }
    }

    public string message = "Hello, Unity!";
    public int fontSize = 24;
    public Color fontColor = Color.white;
    public Rect rect;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ʹ�����ڼ����³���ʱ�����Զ�����
        } else {
            Destroy(gameObject);  // ȷ��ֻ��һ��ʵ������
        }
    }

    void OnGUI() {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = fontSize;
        guiStyle.normal.textColor = fontColor;

        Vector2 size = guiStyle.CalcSize(new GUIContent(message));
        //Rect rect = new Rect((Screen.width - size.x) / 2, (Screen.height - size.y) / 2, size.x, size.y);

        GUI.Label(rect, message, guiStyle);
    }

    public void DisplayMessage(string msg, int size, Color color, Rect rect) {
        message = msg;
        fontSize = size;
        fontColor = color;
        this.rect = rect;
    }
}

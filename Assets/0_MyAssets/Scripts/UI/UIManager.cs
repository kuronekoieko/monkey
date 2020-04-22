using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 画面UIの一括管理
/// GameDirectorと各画面を中継する役割
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameDirector;
    public static UIManager i;
    BaseCanvasManager[] canvases;

    //Awakeより先に呼ばれる
    //シーンをリロードしても呼ばれない
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RuntimeInitializeApplication()
    {
        // SceneManager.LoadScene("UIScene");
    }

    void Awake()
    {
        i = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        DontDestroyOnLoad(gameDirector);
    }

    void Start()
    {
        i = this;
        canvases = new BaseCanvasManager[transform.childCount];
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i] = transform.GetChild(i).GetComponent<BaseCanvasManager>();
            if (canvases[i] == null) { continue; }
            canvases[i].OnStart();
        }
    }

    void Update()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            if (canvases[i] == null) { continue; }
            canvases[i].OnUpdate();
        }

    }
}

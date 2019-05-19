using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameStart : MonoSingleton<GameStart>
{
    private GameObject m_obj;
    protected override void Awake()
    {
        base.Awake();
        GameObject.DontDestroyOnLoad(gameObject);
        ResourceManager.Instance.Init(this);
        ObjectManager.Instance.Init(transform.Find("RecyclePoolTrs"), transform.Find("SceneTrs"));
        HotPatchManager.Instance.Init(this);
        UIManager.Instance.Init(transform.Find("UIRoot") as RectTransform, transform.Find("UIRoot/WndRoot") as RectTransform, transform.Find("UIRoot/UICamera").GetComponent<Camera>(), transform.Find("UIRoot/EventSystem").GetComponent<EventSystem>());
        RegisterUI();
    }
    
    void Start ()
    {
        UIManager.Instance.PopUpWnd(ConStr.HOTFIX, resource: true);
    }

    public IEnumerator StartGame(Image image, Text text)
    {
        image.fillAmount = 0;
        yield return null;
        text.text = "加载本地数据... ...";
        AssetBundleManager.Instance.LoadAssetBundleConfig();
        image.fillAmount = 0.1f;
        yield return null;
        text.text = "加载dll... ...";
        ILRuntimeManager.Instance.Init();
        image.fillAmount = 0.2f;
        yield return null;
        text.text = "加载数据表... ...";
        LoadConfiger();
        image.fillAmount = 0.7f;
        yield return null;
        text.text = "加载配置... ...";
        image.fillAmount = 0.9f;
        yield return null;
        text.text = "初始化地图... ...";
        GameMapManager.Instance.Init(this);
        image.fillAmount = 1f;
        yield return null;
    }

    //注册UI窗口
    void RegisterUI()
    {
        UIManager.Instance.Register<Window>(ConStr.MENUPANEL);
        UIManager.Instance.Register<Window>(ConStr.LOADINGPANEL);
        UIManager.Instance.Register<HotFixUi>(ConStr.HOTFIX);
    }

    //加载配置表
    void LoadConfiger()
    {
        //ConfigerManager.Instance.LoadData<MonsterData>(CFG.TABLE_MONSTER);
        //ConfigerManager.Instance.LoadData<BuffData>(CFG.TABLE_BUFF);
    }
	
	// Update is called once per frame
	void Update ()
    {
        UIManager.Instance.OnUpdate();
	}

    public static void OpenCommonConfirm(string title, string str, UnityEngine.Events.UnityAction confirmAction, UnityEngine.Events.UnityAction cancleAction)
    {
        GameObject commonObj = GameObject.Instantiate(Resources.Load<GameObject>("CommonConfirm")) as GameObject;
        commonObj.transform.SetParent(UIManager.Instance.m_WndRoot, false);
        CommonConfirm commonItem = commonObj.GetComponent<CommonConfirm>();
        commonItem.Show(title,str, confirmAction, cancleAction);
    }

    private void OnApplicationQuit()
    {
#if UNITY_EDITOR
        ResourceManager.Instance.ClearCache();
        Resources.UnloadUnusedAssets();
        Debug.Log("清空编辑器缓存");
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotFixUi : Window
{
    private HotFixPanel m_Panel;
    private float m_SumTime = 0;

    public override void Awake(object param1 = null, object param2 = null, object param3 = null)
    {
        m_SumTime = 0;
        m_Panel = GameObject.GetComponent<HotFixPanel>();
        m_Panel.m_Image.fillAmount = 0;
        m_Panel.m_Tex.text = string.Format("{0:F}M/S", 0);
        HotPatchManager.Instance.ServerInfoError += ServerInfoError;
        HotPatchManager.Instance.ItemError += ItemError;

#if UNITY_EDITOR
        StartOnFinish();
#else
        if (HotPatchManager.Instance.ComputeUnPackFile())
        {
            m_Panel.m_SliderTopTex.text = "解压中...";
            HotPatchManager.Instance.StartUnackFile(()=> 
            {
                m_SumTime = 0;
                HotFix();
            });
        }
        else
        {
            HotFix();
        }
#endif
    }

    void HotFix()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //提示网络错误，检测网络链接是否正常
            GameStart.OpenCommonConfirm("网络链接失败", "网络链接失败，请检查网络链接是否正常？", () =>
              { Application.Quit(); }, () => { Application.Quit(); });
        }
        else
        {
            CheckVersion();
        }
    }

    void CheckVersion()
    {
        HotPatchManager.Instance.CheckVersion((hot) =>
        {
            if (hot)
            {
                //提示玩家是否确定热更下载
                GameStart.OpenCommonConfirm("热更确定", string.Format("当前版本为{0},有{1:F}M大小热更包，是否确定下载？", HotPatchManager.Instance.CurVersion, HotPatchManager.Instance.LoadSumSize / 1024.0f), OnClickStartDownLoad, OnClickCancleDownLoad);
            }
            else
            {
                StartOnFinish();
            }
        });
    }

    void OnClickStartDownLoad()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                GameStart.OpenCommonConfirm("下载确认", "当前使用的是手机流量，是否继续下载？", StartDownLoad, OnClickCancleDownLoad);
            }
        }
        else
        {
            StartDownLoad();
        }
    }

    void OnClickCancleDownLoad()
    {
        Application.Quit();
    }

    /// <summary>
    /// 正式开始下载
    /// </summary>
    void StartDownLoad()
    {
        m_Panel.m_SliderTopTex.text = "下载中...";
        m_Panel.m_InfoPanel.SetActive(true);
        m_Panel.m_HotContentTex.text = HotPatchManager.Instance.CurrentPatches.Des;
        GameStart.Instance.StartCoroutine(HotPatchManager.Instance.StartDownLoadAB(StartOnFinish));
    }

    /// <summary>
    /// 下载完成回调，或者没有下载的东西直接进入游戏
    /// </summary>
    void StartOnFinish()
    {
        GameStart.Instance.StartCoroutine(OnFinish());
    }

    IEnumerator OnFinish()
    {
        yield return GameStart.Instance.StartCoroutine(GameStart.Instance.StartGame(m_Panel.m_Image, m_Panel.m_SliderTopTex));
        UIManager.Instance.CloseWnd(this);
    }

    public override void OnUpdate()
    {
        if (HotPatchManager.Instance.StartUnPack)
        {
            m_SumTime += Time.deltaTime;
            m_Panel.m_Image.fillAmount = HotPatchManager.Instance.GetUnpackProgress();
            float speed = (HotPatchManager.Instance.AlreadyUnPackSize / 1024.0f)/ m_SumTime;
            m_Panel.m_Tex.text = string.Format("{0:F} M/S", speed);
        }

        if (HotPatchManager.Instance.StartDownload)
        {
            m_SumTime += Time.deltaTime;
            m_Panel.m_Image.fillAmount = HotPatchManager.Instance.GetProgress();
            float speed = (HotPatchManager.Instance.GetLoadSize() / 1024.0f) / m_SumTime;
            m_Panel.m_Tex.text = string.Format("{0:F} M/S", speed);
        }
    }

    public override void OnClose()
    {
        HotPatchManager.Instance.ServerInfoError -= ServerInfoError;
        HotPatchManager.Instance.ItemError -= ItemError;
        //加载场景
        GameMapManager.Instance.LoadScene(ConStr.MENUSCENE);
    }


    void ServerInfoError()
    {
        GameStart.OpenCommonConfirm("服务器列表获取失败", "服务器列表获取失败，请检查网络链接是否正常？尝试重新下载！", CheckVersion, Application.Quit);
    }

    void ItemError(string all)
    {
        GameStart.OpenCommonConfirm("资源下载失败", string.Format("{0}等资源下载失败，请重新尝试下载！", all), AnewDownload, Application.Quit);
    }

    void AnewDownload()
    {
        HotPatchManager.Instance.CheckVersion((hot) =>
        {
            if (hot)
            {
                StartDownLoad();
            }
            else
            {
                StartOnFinish();
            }
        });
    }
}

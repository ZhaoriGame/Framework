using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TestEditor
{
    //[MenuItem("TTT/TTTT")]
    //public static void JenkinsTest()
    //{
    //    FileInfo fileInfo = new FileInfo(Application.dataPath + "/测试.txt");
    //    StreamWriter sw = fileInfo.CreateText();
    //    sw.WriteLine(System.DateTime.Now);
    //    sw.Close();
    //    sw.Dispose();
    //}

    private static string DLLPATH = "Assets/GameData/Data/HotFix/HotFix.dll";
    private static string PDBPATH = "Assets/GameData/Data/HotFix/HotFix.pdb";

    private static Sprite ttt;

    [MenuItem("测试/测试加载")]
    public static void TestLoad()
    {
        ttt = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/GameData/UGUI/Test1.png");
    }

    [MenuItem("测试/测试卸载")]
    public static void TestUnLoad()
    {
        Resources.UnloadAsset(ttt);
        //对引用进行了释放，但是还存在在编辑器内存
    }

    [MenuItem("Tools/修改热更dll为txt")]
    public static void ChangeDllName()
    {
        if (File.Exists(DLLPATH))
        {
            string targetPath = DLLPATH + ".txt";
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
            File.Move(DLLPATH, targetPath);
        }

        if (File.Exists(PDBPATH))
        {
            string targetPath = PDBPATH + ".txt";
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
            File.Move(PDBPATH, targetPath);
        }
        AssetDatabase.Refresh();
    }
}

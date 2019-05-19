using System;
using UnityEngine;

namespace HotFix
{
    public class TestMono
    {
        public static void RunTest(GameObject go)
        {
            go.AddComponent<MonoTest>();
        }

        public static void RunTest1(GameObject go)
        {
            go.AddComponent<MonoTest>();
            MonoTest monoTest = go.GetComponent<MonoTest>();
            monoTest.Test();
        }
    }

    public class MonoTest : MonoBehaviour
    {
        private float m_CurTime = 0;

        void Awake()
        {
            Debug.Log("MonoTest  Awake!");
        }

        void Start()
        {
            Debug.Log("MonoTest  Start!");
        }

        void Update()
        {
            if (m_CurTime < 0.2f)
            {
                m_CurTime += Time.deltaTime;
                Debug.Log("MonoTest  Update!");
            }
        }

        public void Test()
        {
            Debug.Log("MonoTest!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }
}

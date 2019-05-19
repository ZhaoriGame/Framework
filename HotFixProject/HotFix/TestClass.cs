using System;
using UnityEngine;

namespace HotFix
{
    public class TestClass
    {
        private int m_Id;

        public int ID
        {
            get { return m_Id; }
        }

        public TestClass()
        {

        }

        public TestClass(int id)
        {
            m_Id = id;
        }

        public static void StaticFunTest()
        {
            Debug.Log("TestClass  StaticFunTest!!!!!!!!!!!!!!!!");
        }

        public static void StaticFunTest2(int a)
        {
            Debug.Log("TestClass  StaticFunTest2  a=" + a);
        }

        public static void GenericMethod<T>(T a)
        {
            Debug.Log("TestClass  GenericMethod  a=" + a);
        }
    }
}

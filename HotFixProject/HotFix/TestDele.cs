using System;
using UnityEngine;

namespace HotFix
{
    public class TestDele
    {
        static TestDelegateMeth delegateMethod;
        static TestDelegateFunction delegateFunc;
        static Action<string> delegateAction;

        public static void Initialize()
        {
            delegateMethod = Method;
            delegateFunc = Function;
            delegateAction = Action;
        }

        public static void RunTest()
        {
            if (delegateMethod != null)
            {
                delegateMethod(25);
            }
            if (delegateFunc != null)
            {
                string str = delegateFunc(37);
                Debug.Log("RunTest  delegateFunc" + str);
            }
            if (delegateAction != null)
            {
                delegateAction("Ocean");
            }
        }

        public static void Initialize2()
        {
            ILRuntimeManager.Instance.DelegateMethod = Method;
            ILRuntimeManager.Instance.DelegateFunc = Function;
            ILRuntimeManager.Instance.DelegateAction = Action;
        }

        public static void RunTest2()
        {
            if (ILRuntimeManager.Instance.DelegateMethod != null)
            {
                ILRuntimeManager.Instance.DelegateMethod(25);
            }
            if (ILRuntimeManager.Instance.DelegateFunc != null)
            {
                string str = ILRuntimeManager.Instance.DelegateFunc(37);
                Debug.Log("RunTest  delegateFunc" + str);
            }
            if (ILRuntimeManager.Instance.DelegateAction != null)
            {
                ILRuntimeManager.Instance.DelegateAction("Ocean");
            }
        }

        static void Method(int a)
        {
            Debug.Log("TestDele  Method a=" + a);
        }

        static string Function(int a)
        {
            Debug.Log("TestDele  Function a=" + a);
            return a.ToString();
        }

        static void Action(string str)
        {
            Debug.Log("TestDele  Action str=" + str);
        }
    }
}

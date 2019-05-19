﻿using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(Window);
        }
    }

    public override Type AdaptorType
    {
        get { return typeof(Adaptor); }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);
    }

    public class Adaptor : Window, CrossBindingAdaptorType
    {
        private ILTypeInstance m_Instance;
        private ILRuntime.Runtime.Enviorment.AppDomain m_AppDomain;
        private object[] m_Paralist = new object[3];
        private IMethod m_AwakeMethod;
        private IMethod m_ShowMethod;
        private IMethod m_DisableMethod;
        private IMethod m_UpdateMethod;
        private IMethod m_CloseMethod;
        private IMethod m_ToString;
        private bool m_OnCloseInvoking = false;

        public Adaptor() { }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appDomain, ILTypeInstance instance)
        {
            m_AppDomain = appDomain;
            m_Instance = instance;
        }

        public ILTypeInstance ILInstance
        {
            get
            {
                return m_Instance;
            }
        }

        public override void Awake(object param1 = null, object param2 = null, object param3 = null)
        {
            if (m_AwakeMethod == null)
            {
                m_AwakeMethod = m_Instance.Type.GetMethod("Awake", 3);
            }

            if (m_AwakeMethod != null)
            {
                m_Paralist[0] = param1;
                m_Paralist[1] = param2;
                m_Paralist[2] = param3;
                m_AppDomain.Invoke(m_AwakeMethod,m_Instance, m_Paralist);
            }
        }

        public override void OnShow(object param1 = null, object param2 = null, object param3 = null)
        {
            if (m_ShowMethod == null)
            {
                m_ShowMethod = m_Instance.Type.GetMethod("OnShow", 3);
            }

            if (m_ShowMethod != null)
            {
                m_Paralist[0] = param1;
                m_Paralist[1] = param2;
                m_Paralist[2] = param3;
                m_AppDomain.Invoke(m_ShowMethod, m_Instance, m_Paralist);
            }
        }

        public override void OnDisable()
        {
            if (m_DisableMethod == null)
            {
                m_DisableMethod = m_Instance.Type.GetMethod("OnDisable", 3);
            }

            if (m_DisableMethod != null)
            {
                m_AppDomain.Invoke(m_DisableMethod, m_Instance);
            }
        }

        public override void OnUpdate()
        {
            if (m_UpdateMethod == null)
            {
                m_UpdateMethod = m_Instance.Type.GetMethod("OnUpdate", 3);
            }

            if (m_UpdateMethod != null)
            {
                m_AppDomain.Invoke(m_UpdateMethod, m_Instance);
            }
        }

        public override void OnClose()
        {
            if (m_CloseMethod == null)
            {
                m_CloseMethod = m_Instance.Type.GetMethod("OnClose", 3);
            }

            if (m_CloseMethod != null && !m_OnCloseInvoking)
            {
                m_OnCloseInvoking = true;
                m_AppDomain.Invoke(m_CloseMethod, m_Instance);
                m_OnCloseInvoking = false;
            }
            else
            {
                base.OnClose();
            }
        }

        //OnMessage自己处理


        public override string ToString()
        {
            if (m_ToString == null)
            {
                m_ToString = m_AppDomain.ObjectType.GetMethod("ToString", 0);
            }
            IMethod m = m_Instance.Type.GetVirtualMethod(m_ToString);
            if (m == null || m is ILMethod)
            {
                return m_Instance.ToString();
            }
            else
            {
                return m_Instance.Type.FullName;
            }
        }
    }
}

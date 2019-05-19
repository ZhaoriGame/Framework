using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ILRuntimeManager_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ILRuntimeManager);

            field = type.GetField("DelegateMethod", flag);
            app.RegisterCLRFieldGetter(field, get_DelegateMethod_0);
            app.RegisterCLRFieldSetter(field, set_DelegateMethod_0);
            field = type.GetField("DelegateFunc", flag);
            app.RegisterCLRFieldGetter(field, get_DelegateFunc_1);
            app.RegisterCLRFieldSetter(field, set_DelegateFunc_1);
            field = type.GetField("DelegateAction", flag);
            app.RegisterCLRFieldGetter(field, get_DelegateAction_2);
            app.RegisterCLRFieldSetter(field, set_DelegateAction_2);


        }



        static object get_DelegateMethod_0(ref object o)
        {
            return ((ILRuntimeManager)o).DelegateMethod;
        }
        static void set_DelegateMethod_0(ref object o, object v)
        {
            ((ILRuntimeManager)o).DelegateMethod = (TestDelegateMeth)v;
        }
        static object get_DelegateFunc_1(ref object o)
        {
            return ((ILRuntimeManager)o).DelegateFunc;
        }
        static void set_DelegateFunc_1(ref object o, object v)
        {
            ((ILRuntimeManager)o).DelegateFunc = (TestDelegateFunction)v;
        }
        static object get_DelegateAction_2(ref object o)
        {
            return ((ILRuntimeManager)o).DelegateAction;
        }
        static void set_DelegateAction_2(ref object o, object v)
        {
            ((ILRuntimeManager)o).DelegateAction = (System.Action<System.String>)v;
        }


    }
}

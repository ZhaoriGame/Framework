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
    unsafe class GameMapManager_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(GameMapManager);

            field = type.GetField("LoadingProgress", flag);
            app.RegisterCLRFieldGetter(field, get_LoadingProgress_0);
            app.RegisterCLRFieldSetter(field, set_LoadingProgress_0);


        }



        static object get_LoadingProgress_0(ref object o)
        {
            return GameMapManager.LoadingProgress;
        }
        static void set_LoadingProgress_0(ref object o, object v)
        {
            GameMapManager.LoadingProgress = (System.Int32)v;
        }


    }
}

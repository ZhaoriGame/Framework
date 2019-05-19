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
    unsafe class MenuPanel_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(MenuPanel);

            field = type.GetField("m_StartButton", flag);
            app.RegisterCLRFieldGetter(field, get_m_StartButton_0);
            app.RegisterCLRFieldSetter(field, set_m_StartButton_0);
            field = type.GetField("m_LoadButton", flag);
            app.RegisterCLRFieldGetter(field, get_m_LoadButton_1);
            app.RegisterCLRFieldSetter(field, set_m_LoadButton_1);
            field = type.GetField("m_ExitButton", flag);
            app.RegisterCLRFieldGetter(field, get_m_ExitButton_2);
            app.RegisterCLRFieldSetter(field, set_m_ExitButton_2);
            field = type.GetField("m_Test1", flag);
            app.RegisterCLRFieldGetter(field, get_m_Test1_3);
            app.RegisterCLRFieldSetter(field, set_m_Test1_3);
            field = type.GetField("m_Test3", flag);
            app.RegisterCLRFieldGetter(field, get_m_Test3_4);
            app.RegisterCLRFieldSetter(field, set_m_Test3_4);
            field = type.GetField("m_Test2", flag);
            app.RegisterCLRFieldGetter(field, get_m_Test2_5);
            app.RegisterCLRFieldSetter(field, set_m_Test2_5);


        }



        static object get_m_StartButton_0(ref object o)
        {
            return ((MenuPanel)o).m_StartButton;
        }
        static void set_m_StartButton_0(ref object o, object v)
        {
            ((MenuPanel)o).m_StartButton = (UnityEngine.UI.Button)v;
        }
        static object get_m_LoadButton_1(ref object o)
        {
            return ((MenuPanel)o).m_LoadButton;
        }
        static void set_m_LoadButton_1(ref object o, object v)
        {
            ((MenuPanel)o).m_LoadButton = (UnityEngine.UI.Button)v;
        }
        static object get_m_ExitButton_2(ref object o)
        {
            return ((MenuPanel)o).m_ExitButton;
        }
        static void set_m_ExitButton_2(ref object o, object v)
        {
            ((MenuPanel)o).m_ExitButton = (UnityEngine.UI.Button)v;
        }
        static object get_m_Test1_3(ref object o)
        {
            return ((MenuPanel)o).m_Test1;
        }
        static void set_m_Test1_3(ref object o, object v)
        {
            ((MenuPanel)o).m_Test1 = (UnityEngine.UI.Image)v;
        }
        static object get_m_Test3_4(ref object o)
        {
            return ((MenuPanel)o).m_Test3;
        }
        static void set_m_Test3_4(ref object o, object v)
        {
            ((MenuPanel)o).m_Test3 = (UnityEngine.UI.Image)v;
        }
        static object get_m_Test2_5(ref object o)
        {
            return ((MenuPanel)o).m_Test2;
        }
        static void set_m_Test2_5(ref object o, object v)
        {
            ((MenuPanel)o).m_Test2 = (UnityEngine.UI.Image)v;
        }


    }
}

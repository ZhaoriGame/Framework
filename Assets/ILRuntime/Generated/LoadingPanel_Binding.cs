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
    unsafe class LoadingPanel_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(LoadingPanel);

            field = type.GetField("m_Slider", flag);
            app.RegisterCLRFieldGetter(field, get_m_Slider_0);
            app.RegisterCLRFieldSetter(field, set_m_Slider_0);
            field = type.GetField("m_Text", flag);
            app.RegisterCLRFieldGetter(field, get_m_Text_1);
            app.RegisterCLRFieldSetter(field, set_m_Text_1);


        }



        static object get_m_Slider_0(ref object o)
        {
            return ((LoadingPanel)o).m_Slider;
        }
        static void set_m_Slider_0(ref object o, object v)
        {
            ((LoadingPanel)o).m_Slider = (UnityEngine.UI.Slider)v;
        }
        static object get_m_Text_1(ref object o)
        {
            return ((LoadingPanel)o).m_Text;
        }
        static void set_m_Text_1(ref object o, object v)
        {
            ((LoadingPanel)o).m_Text = (UnityEngine.UI.Text)v;
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Jyz.Infrastructure
{
    public class Utils
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="isAddEmpty"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetEnumDict<T>(bool isAddEmpty = false)where T : Enum
        {
            var type = typeof(T);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (isAddEmpty)
            {
                dict.Add("", "");
            }
            foreach (int i in Enum.GetValues(type))
            {
                string name = GetEnumName(type, i);
                dict.Add(i.ToString(), name);
            }
            return dict;
        }
        public static string GetEnumName(Type type, int value)
        {
            var t = Enum.Parse(type, Enum.GetName(type, value));
            MemberInfo[] memInfo = type.GetMember(t.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return t.ToString();//如果不存在描述，则返回枚举名称
        }
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", string.Empty);
            return t2;
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string password = "")
        {
            string pwd = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password))
                {
                    MD5 md5 = MD5.Create(); //实例化一个md5对像
                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                    // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
                    foreach (var item in s)
                    {
                        // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                        pwd = string.Concat(pwd, item.ToString("X2"));
                    }
                }
            }
            catch
            {
                throw new Exception($"错误的 password 字符串:【{password}】");
            }
            return pwd;
        }

        /// <summary>
        /// 64位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt64(string password)
        {
            // 实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(s);
        }
        /// <summary>
        /// 生成树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        public static void CreateTree<T>(T node, List<T> list, List<T> tree = null)where T : ITreeNode<T>
        {
            if (node==null)
            {
                var parents = list.Where(x => x.PId == null).ToList();
                foreach (var p in parents)
                {
                    tree.Add(p);
                    CreateTree(p, list);
                }
            }
            else
            {
                var childrens = list.Where(x => x.PId == node.Id).ToList();
                foreach (var c in childrens)
                {
                    node.Children.Add(c);
                    CreateTree(c, list);
                }
            }
        }
    }
}

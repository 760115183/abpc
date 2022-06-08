using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lis.PiYanSuoReport.Common.Extension
{
    public static class CommonExtension
    {
        /// <summary>
        /// 利用反射来判断对象是否包含某个属性
        /// </summary>
        /// <param name="instance">object</param>
        /// <param name="propertyName">需要判断的属性</param>
        /// <returns>是否包含</returns>
        public static bool ContainProperty(this object instance, string propertyName)
        {
            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
                return (_findedPropertyInfo != null);
            }
            return false;
        }

        /// <summary>
        /// 利用反射来判断对象是否包含某个属性
        /// </summary>
        /// <param name="instance">object</param>
        /// <param name="propertyName">需要判断的属性</param>
        /// <returns>是否包含</returns>
        public static bool ContainProperty(Type type , string propertyName)
        {
            if (type != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo _findedPropertyInfo = type.GetProperty(propertyName);
                return (_findedPropertyInfo != null);
            }
            return false;
        }

        public static bool IsNull(this object obj)
        {
            bool result = obj == null;
            return result;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            bool result = String.IsNullOrEmpty(str);
            return result;
        }

        public static bool IsNotNullAndNotEmpty(this string str)
        {
            bool result = !String.IsNullOrEmpty(str);
            return result;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            bool result = list == null || !list.Any();
            return result;
        }

        public static IList<T> AddItmes<T>(this IList<T> list1, IEnumerable<T> list2)
        {
            if (list1.IsNull() || list2.IsNull())
            {
                return list1;
            }
            list2.All(item => { list1.Add(item); return true; });
            return list1;
        }

        public static bool IsDouble(this string s)
        {
            double d = 0;
            bool result = !s.IsNullOrEmpty() && double.TryParse(s, out d);
            return result;
        }

        public static string Int2DiskSize(this int size)
        {
            const int sizeLevel = 1024;
            if (size < sizeLevel)
            {
                return "{0} Bytes".StrFormat(size);
            }
            else if (size > sizeLevel && size < Math.Pow(sizeLevel, 2))
            {
                return "{0:f1} KB".StrFormat(size / (1.0 * sizeLevel));
            }
            else if (size > Math.Pow(sizeLevel, 2) && size < Math.Pow(sizeLevel, 3))
            {
                return "{0:f2} MB".StrFormat(size / (1.0 * Math.Pow(sizeLevel, 2)));
            }
            else
            {
                return "{0:f2} GB".StrFormat(size / (1.0 * Math.Pow(sizeLevel, 3)));
            }
        }

        /// <summary>
        /// same as string.StartsWith, IgnoreCase
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static bool IsStartsWith(this string strA, string strB)
        {
            if (string.IsNullOrEmpty(strA) || string.IsNullOrEmpty(strB)) return false;
            return strA.StartsWith(strB, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// same as string.contains, IgnoreCase
        /// </summary>
        /// <param name="sourceValue"></param>
        /// <param name="testValue"></param>
        /// <returns></returns>
        public static bool IsContains(this string sourceValue, string testValue)
        {
            if (string.IsNullOrEmpty(sourceValue) || string.IsNullOrEmpty(testValue)) return false;
            return sourceValue.ToUpperInvariant().Contains(testValue.ToUpperInvariant());
        }

        public static string StrFormat(this string str, params object[] args)
        {
            if (str.IsNullOrEmpty())
            {
                return str;
            }
            return string.Format(str, args);
        }

        #region File
        public static bool IsFileExists(this string filePath)
        {
            bool result = !filePath.IsNullOrEmpty() && File.Exists(filePath);
            return result;
        }
        public static bool IsFolderExists(this string folderPath)
        {
            bool result = !folderPath.IsNullOrEmpty() && Directory.Exists(folderPath);
            return result;
        }

        public static bool DeleteFile(this string filePath)
        {
            bool result = false;
            if (filePath.IsFileExists())
            {
                try
                {
                    File.Delete(filePath);
                    result = true;
                }
                catch (Exception ex)
                {
                    //Logger.Instance.Error("Delete file:{0} failed".StrFormat(filePath), ex);
                }
            }
            return result;
        }              

        #endregion

        #region List

        public static IList<T> Clone<T>(this IEnumerable<T> list) where T : class, ICloneable
        {
            IList<T> result = new List<T>();
            if (list.IsNullOrEmpty())
            {
                return result;
            }

            foreach (var item in list)
            {
                result.Add(item.Clone() as T);
            }

            return result;
        }

        #endregion        

        public static string GetDescription(this object obj, string name = null)
        {
            string result = string.Empty;
            if (name.IsNull())
            {
                name = obj.ToString();
            }

            Type type = obj.GetType();
            foreach (Attribute attr in type.GetCustomAttributes(false))
            {
                if (attr is DescriptionAttribute)
                {
                    result = (attr as DescriptionAttribute).Description;
                    break;
                }
            }

            if (result.IsNullOrEmpty())
            {
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (prop.Name == name)
                    {
                        DescriptionAttribute attr = prop.GetCustomAttribute<DescriptionAttribute>();
                        if (!attr.IsNull())
                        {
                            result = (attr as DescriptionAttribute).Description;
                            break;
                        }
                    }
                }
            }

            if (result.IsNullOrEmpty())
            {
                foreach (FieldInfo fi in type.GetFields())
                {
                    if (fi.Name == name)
                    {
                        DescriptionAttribute attr = fi.GetCustomAttribute<DescriptionAttribute>();
                        if (!attr.IsNull())
                        {
                            result = (attr as DescriptionAttribute).Description;
                            break;
                        }
                    }
                }
            }

            if (result.IsNullOrEmpty())
            {
                // 遍历方法特性
                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name != name)
                    {
                        continue;
                    }

                    foreach (Attribute attr in m.GetCustomAttributes(false))
                    {
                        if (attr is DescriptionAttribute)
                        {
                            result = (attr as DescriptionAttribute).Description;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}

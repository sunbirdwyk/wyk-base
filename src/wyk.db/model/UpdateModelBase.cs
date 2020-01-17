using System;
using System.Reflection;
using wyk.basic;

namespace wyk.db
{
    public class UpdateModelBase
    {
        /// <summary>
        /// 把当前UpdateMode的值赋给原实例
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public void setValuesTo<T>(ref T target)
        {
            var fields = this.GetType().GetFields();
            foreach (var fi in fields)
            {
                var is_null = false;
                object target_value = null;
                var tfi = target.GetType().GetField(fi.Name);
                PropertyInfo tpi = null;
                if (tfi == null)
                    tpi = target.GetType().GetProperty(fi.Name);
                if (tfi != null)
                {
                    target_value = tfi.GetValue(target);
                    is_null = tfi.isNullValue(target);
                }
                else if (tpi != null)
                {
                    target_value = tpi.GetValue(target);
                    is_null = tpi.isNullValue(target);
                }
                var tag = fi.getAttribute<UpdateModelMethodAttribute>();
                if (tag == null)
                    tag = new UpdateModelMethodAttribute();
                var fi_value = fi.GetValue(this);
                if (tag.method == UpdateModelMethod.SetWhenNull)
                {
                    if (is_null)
                    {
                        if (tfi != null)
                            target.setValue(tfi, fi_value);
                        else if (tpi != null)
                            target.setValue(tpi, fi_value);
                    }
                }
                else if(tag.method == UpdateModelMethod.SetWhenNew)
                {
                    try
                    {
                        if (Convert.ToBoolean(target.getValue("is_new")))
                        {
                            if (tfi != null)
                                target.setValue(tfi, fi_value);
                            else if (tpi != null)
                                target.setValue(tpi, fi_value);
                        }
                    }
                    catch { }
                }
                else if(tag.method== UpdateModelMethod.SetIfUpdateNotNull)
                {
                    try
                    {
                        if (!fi.isNullValue(this))
                        {
                            if (tfi != null)
                                target.setValue(tfi, fi_value);
                            else if (tpi != null)
                                target.setValue(tpi, fi_value);
                        }
                    }
                    catch { }
                }
                else
                {
                    if (tfi != null)
                        target.setValue(tfi, fi_value);
                    else if (tpi != null)
                        target.setValue(tpi, fi_value);
                }
            }
        }

        /// <summary>
        /// 判断当前内容是否符合最低要求(如有字段限制需要在子类重写)
        /// </summary>
        /// <returns></returns>
        public virtual string checkAvailable()
        {
            return "";
        }
    }
}
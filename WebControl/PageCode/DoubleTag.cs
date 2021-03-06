﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Web.Mvc;

namespace WebControl.PageCode
{
    /// <summary>
    /// 成对标签类
    /// </summary>
    public class DoubleTag
    {
        private string Tag;

        private Dictionary<string, string> Attr;

        private StringBuilder sb = new StringBuilder();

        private DoubleTag() { }

        /// <summary>
        /// 成对标签 标签参数
        /// </summary>
        /// <param name="attr">属性</param>
        public DoubleTag(string tag, Dictionary<string, string> attr)
        {
            this.Tag = tag;
            this.Attr = attr;
            this.GetHTML();
        }

        public virtual void GetHTML()
        {
            sb.Append(string.Format("<{0} ", this.Tag));
            if (Attr != null)
            {
                foreach (var item in Attr)
                    sb.Append(item.Key + "=\"" + item.Value + "\" ");
                sb.Append(">");
            }
        }

        /// <summary>
        /// 向div 里面添加东西
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual DoubleTag Append(string text)
        {
            sb.Append(text);
            return this;
        }

        /// <summary>
        /// 控件参数配置完后 执行此函数即可得到控件
        /// </summary>
        /// <returns></returns>
        public virtual MvcHtmlString Create()
        {
            sb.Append(string.Format("</{0}>", this.Tag));
            return MvcHtmlString.Create(sb.ToString());
        }



    }
}

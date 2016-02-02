using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_boilerplate.BL
{
    public class WebViewBasePage<T> : WebViewPage<T>
    {
        public string MyProperty { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            MyProperty = "Hello";
        }

        public override void Execute()
        {
        }
    }
}
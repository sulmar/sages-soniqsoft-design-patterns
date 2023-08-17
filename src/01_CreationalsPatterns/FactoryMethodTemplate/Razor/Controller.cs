﻿using FactoryMethodTemplate.Hugo;
using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    // Creator
    public class Controller
    {
        public string Render(string viewName, IDictionary<string, object> context
            )
        {
            var engine = CreateViewEngine();
            var html = engine.Render(viewName, context);

            return html;
        }

        protected virtual IViewEngine CreateViewEngine()
        {
            return new RazorViewEngine();
        }
    }

    // Creator
    public class HugoController : Controller
    {
        protected override IViewEngine CreateViewEngine()
        {
            return new HugoViewEngine();
        }
    }
}

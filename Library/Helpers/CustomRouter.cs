using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Helpers
{
    public class CustomRouter : IRouter
    {
        private IRouter _defaultRouter;

        public CustomRouter(IRouter defaultRouter)
        {
            _defaultRouter = defaultRouter;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return _defaultRouter.GetVirtualPath(context);
        }

        public async Task RouteAsync(RouteContext context)
        {
            var headers = context.HttpContext.Request.Headers;            
            var path = context.HttpContext.Request.Path.Value.Split('/');
            var deneme = context.HttpContext.Request.Path;

            if (headers.ContainsKey("User-Agent") && headers["User-Agent"].ToString().Contains("Mobile"))
            {
                var action = "Index";
                var controller = "";

                if (path.Length > 1)
                {
                    controller = path[1];
                    if (path.Length > 2)
                        action = path[2];
                }

                context.RouteData.Values["controller"] = $"Mobile{controller}";
                context.RouteData.Values["action"] = action;

                await _defaultRouter.RouteAsync(context);
            }
        }
    }
}

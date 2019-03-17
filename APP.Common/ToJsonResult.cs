using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace APP.Common
{
    public class ToJsonResult:JsonResult
    {
        const string error = "该请求已经被封锁，因为敏感信息透漏给第三方网站，这是一个GET请求时使用的。为了可以GET请求，请设置JsonRequestBehavior.AllowGet";

        public string FormateStr { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if(context == null)
            {
                throw new ArgumentException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(error);
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!string.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if(ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if(Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonString = serializer.Serialize(Data);

                string p = @"\\/Date\(\d+\)\\/";

                MatchEvaluator matchEvaluator = new MatchEvaluator(ConverJsonDateToDateString);

                Regex reg = new Regex(p);

                jsonString = reg.Replace(jsonString, matchEvaluator);

                response.Write(jsonString);
            }
        }

        private string ConverJsonDateToDateString(Match m)
        {
            string result = string.Empty;

            string p = @"\d";

            var cArray = m.Value.ToCharArray();

            StringBuilder sb = new StringBuilder();

            Regex reg = new Regex(p);

            foreach(var item in cArray)
            {
                if (reg.IsMatch(item.ToString()))
                {
                    sb.Append(item);
                }
            }

            DateTime dt = new DateTime(1970, 1, 1);

            dt = dt.AddMilliseconds(long.Parse(sb.ToString()));

            dt = dt.ToLocalTime();

            result = dt.ToString("yyyy-MM-dd HH:mm:ss");

            return result;

        }
    }
}

#region Usings
using System;
using System.IO; 
#endregion

namespace Intech.PrevSystemWeb.Api
{
    public class BaseUploadController : BaseController
    {
        public static string DiretorioUpload =>
            Path.Combine(Environment.CurrentDirectory, "Upload");
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Application.Static_Tools
{
    public static class FilePath
    {
        #region User

        public static readonly string UserProfileDefault = "/images/user/default/avatar";
        public static readonly string UploadImageProfile = "/images/user/profile/";
        public static readonly string UploadImageProfileServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/user/profile/");

        #endregion
    }
}

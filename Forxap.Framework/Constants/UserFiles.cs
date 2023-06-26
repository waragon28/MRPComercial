//#define AD_PE
#define AD_BO
//#define AD_PY
//#define AD_EC
//#define AD_CL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.Framework.Constants
{
    public class UserFiles
    {


        #if AD_BO
                public const string FolderHana = "/Scripts/Hana/Bolivia/";
        #elif AD_BO
                public const string FolderHana = "/Scripts/Hana/Paraguay/";
        #elif AD_BO
                public const string FolderHana = "/Scripts/Hana/Ecuador/";
        #elif AD_BO
                public const string FolderHana = "/Scripts/Hana/Chile/";
        #else
                public const string FolderHana = "/Scripts/Peru/";
        #endif

        public const string FolderSQL = "/Scripts/SQL/";
        
    }
}

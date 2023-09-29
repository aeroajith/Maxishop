using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Application_Constants
{
    public class ApplicationConstant
    {

    }

    public class CommonMessage
    {
        public const string CreateOperationSuccess = "Record created successfully";
        public const string UpdateOperationSuccess = "Record updated successfully";
        public const string DeleteOperationSuccess = "Record deleted successfully";


        public const string CreateOperationFailed = "Record creation Failed";
        public const string UpdateOperationFailed = "Record updation Failed";
        public const string DeleteOperationFailed = "Record deletion Failed";

        public const string RecordNotFound = "RecordNotFound";
        public const string SystemError = "Something went wrong";


    }
}

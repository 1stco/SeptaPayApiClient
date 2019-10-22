using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeptaPay.Api.Client.Net4.Extensions {
    public static class ApplicationExtensions {

        public static void CheckArgumentIsNull(this object obj, string argumentName) {
            if (obj == null)
                throw new ArgumentNullException(argumentName);
        }

        public static void CheckReferenceIsNull(this object obj, string message) {
            if (obj == null)
                throw new NullReferenceException(message);
        }

    }
}

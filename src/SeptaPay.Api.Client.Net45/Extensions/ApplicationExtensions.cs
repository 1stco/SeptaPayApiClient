using System;

namespace SeptaPay.Api.Client.Net45.Extensions {
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

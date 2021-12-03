using System;

namespace HpLayer.Extensions {
    public static class GuardExtensions {
        /// <summary>
        /// checks if the argument is null.
        /// </summary>
        public static void IsArgumentNull (this object o, string name) {
            if (o == null)
                throw new ArgumentNullException (name);
        }
    }
}
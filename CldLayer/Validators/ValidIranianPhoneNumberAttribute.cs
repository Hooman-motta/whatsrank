using System;
using System.ComponentModel.DataAnnotations;

namespace CldLayer.Validators {
    /// <summary>
    /// Determines whether the specified value of the object is a valid IranianPhoneNumber.
    /// </summary>
    [AttributeUsage (AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class ValidIranianPhoneNumberAttribute : ValidationAttribute {
        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        public override bool IsValid (object value) {
            if (value == null) {
                return true; // returning false, makes this field required.
            }
            return value.ToString ().IsValidIranianPhoneNumber ();
        }
    }
}
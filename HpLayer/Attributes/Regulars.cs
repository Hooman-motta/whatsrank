using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HpLayer.Attributes {
    public class PersianLettersRegular : RegularExpressionAttribute, IClientModelValidator {
        private const string _pattern = @"^[\u0600-\u06FF,\u0590-\u05FF\s]*$";
        public PersianLettersRegular (string pattern = _pattern) : base (pattern) {
            ErrorMessage = "لطفا از حروف فارسی استفاده نمائید";
        }
        public void AddValidation (ClientModelValidationContext context) {
            context.Attributes.Add ("style", "direction: rtl");
            context.Attributes.Add ("data-val-regex", ErrorMessage);
            context.Attributes.Add ("data-val-regex-pattern", _pattern);
        }
    }

    public class EnglishLettersRegular : RegularExpressionAttribute, IClientModelValidator {
        private const string _pattern = "^[a-zA-Z_]*$";
        public EnglishLettersRegular (string pattern = _pattern) : base (pattern) {
            ErrorMessage = "لطفا از حروف انگلیسی استفاده نمائید";
        }
        public void AddValidation (ClientModelValidationContext context) {
            context.Attributes.Add ("style", "direction: ltr");
            context.Attributes.Add ("data-val-regex", ErrorMessage);
            context.Attributes.Add ("data-val-regex-pattern", _pattern);
        }
    }

    public class CellNumberRegular : RegularExpressionAttribute, IClientModelValidator {
        private const string _pattern = @"^(\+98|0)?9\d{9}$";
        public CellNumberRegular (string pattern = _pattern) : base (pattern) {
            ErrorMessage = "شماره همراه وارد شده معتبر نیست";
        }
        public void AddValidation (ClientModelValidationContext context) {
            context.Attributes.Add ("style", "direction: ltr");
            context.Attributes.Add ("data-val", "true");
            context.Attributes.Add ("data-val-regex", ErrorMessage);
            context.Attributes.Add ("data-val-regex-pattern", _pattern);
        }
    }

    public class PhoneNumberRegular : RegularExpressionAttribute, IClientModelValidator {
        private const string _pattern = @"^(\+98|0)\d{10}$";
        public PhoneNumberRegular (string pattern = _pattern) : base (pattern) {
            ErrorMessage = "شماره تلفن وارد شده معتبر نیست";
        }
        public void AddValidation (ClientModelValidationContext context) {
            context.Attributes.Add ("style", "direction: ltr");
            context.Attributes.Add ("data-val-regex", ErrorMessage);
            context.Attributes.Add ("data-val-regex-pattern", _pattern);
        }
    }

    public class NumericOnlyRegular : RegularExpressionAttribute, IClientModelValidator {
        private const string _pattern = @"^[0-9]*$";
        public NumericOnlyRegular (string pattern = _pattern) : base (pattern) {
            ErrorMessage = "فقط عدد معتبر است";
        }
        public void AddValidation (ClientModelValidationContext context) {
            context.Attributes.Add ("style", "direction: ltr");
            context.Attributes.Add ("data-val-regex", ErrorMessage);
            context.Attributes.Add ("data-val-regex-pattern", _pattern);
        }
    }
}
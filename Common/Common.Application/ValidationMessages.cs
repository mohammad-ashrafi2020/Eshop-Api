using System;

namespace Common.Application
{
    public class ValidationMessages
    {
        public const string RecaptchaError = "اعتبار سنجی Recaptcha انجام نشد";
        public const string Required = "این فیلد اجباری است";

        public static string required(string field) => $"{field} اجباری است ";
        public static string maxLength(string field, int maxLength) => $"{field} باید کمتر از {maxLength} کاراکتر باشد";
        public static string minLength(string field, int minLength) => $"{field} باید بیشتر از {minLength} کاراکتر باشد";
    


}
}
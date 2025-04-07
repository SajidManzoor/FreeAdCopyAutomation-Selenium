using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeAdCopyAutomation
{
    public static class Environment
    {
        public static string BaseUrl { get; } = "https://freeadcopy.com/";
        public static string ValidEmail { get; } = "sajidfree7727@gmail.com";
        public static string InValidEmail { get; }= "sajid@gmail.com";
        public static string ValidPassword { get; } = "webdir123R";
        public static string NewPassword { get; } = "asdfghj";
        public static string ConfirmNewPassword { get; } = "qwrtyuz";
        public static string LoginSuccessToastMessage { get; } = "Login successfully";
        public static string AuthenticationErrorMessage { get; } = "Firebase: Error (auth/user-not-found).";
        public static string PasswordMismatchToastMessage { get; } = "Password doesn't match";
        public static string BugDetail { get; } = "This is test bug";
        public static string TargetMarketText { get; } = "Target Market";
        public static string PainPointText { get; } = "Pain Point";
        public static string DislikeText { get; } = "Dislike";
        public static string UniqueSolText { get; } = "Unique Solution";

    }
}

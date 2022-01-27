namespace Spinutech_Demo.Models
{
    public class PalindromeResultModel
    {
        public PalindromeResultModel()
        {
            isValid = true;
            isPalindrome = true;
        }

        public bool isValid { get; set; }

        public bool isPalindrome { get; set; }

        public string originalNumber { get; set; }

        public string reversedNumber { get; set; }

        public string numberAsText { get; set; }
    }
}

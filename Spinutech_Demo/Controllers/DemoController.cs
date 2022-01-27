using Microsoft.AspNetCore.Mvc;
using Spinutech_Demo.Models;
using System;
using System.Text.RegularExpressions;
using Humanizer;

namespace Spinutech_Demo.Controllers
{
    public class DemoController : Controller
    {
        [HttpPost]
        public IActionResult EvaluatePalindrome(PalindromeFormModel formModel)
        {
            var model = new PalindromeResultModel
            {
                originalNumber = formModel.EnteredValue
            };

            // if the value provided is anything other than a positive number, fail right away
            if (String.IsNullOrWhiteSpace(formModel.EnteredValue) || !Regex.IsMatch(formModel.EnteredValue, @"^\d+$"))
            {
                model.isValid = false;
                return View("~/Views/Demo/PalindromeResult.cshtml", model);
            }


            var original = model.originalNumber.ToCharArray();
            var reversed = model.originalNumber.ToCharArray();
            Array.Reverse(reversed);

            model.reversedNumber = new string(reversed);

            // just for fun, found a NuGet package that kind of does exercise 1 after I had decided to do exercise 6
            var parsedInt = 0;
            int.TryParse(formModel.EnteredValue, out parsedInt);
            model.numberAsText = parsedInt > 0 ?  parsedInt.ToWords() : "";

            for(int i = 0; i < original.Length; i++)
            {
                if (original[i] != reversed[i])
                {
                    // as soon as any comparison fails we're ready to fail it
                    model.isPalindrome = false;
                    return View("~/Views/Demo/PalindromeResult.cshtml", model);
                }
            }

            return View("~/Views/Demo/PalindromeResult.cshtml", model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Model.ValueObjects
{
    public class ValidateVariable
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public ValidateVariable()
        {
        }

        public void String(int min, int max, string text, string variable)
        {
            if (text.Equals(null))
            {
                Message = $"The ${variable} variable is undefined";
                Success = false;
            }
            else if (text.Length < min)
            {
                Message = $"The ${variable} variable is less than ${min}";
                Success = false;
            }
            else if (text.Length > max)
            {
                Message = $"The ${variable} variable is greater than ${max}";
                Success = false;
            }
            else
            {
                Success = true;
            }
        }

        public void String(int min, string text, string variable)
        {
            if (text.Equals(null))
            {
                Message = $"The ${variable} variable is undefined";
                Success = false;
            }
            else if (text.Length < min)
            {
                Message = $"The ${variable} variable is less than ${min}";
                Success = false;
            }
            else
            {
                Success = true;
            }
        }

        public void Password(int min, int max, string text, string variable)
        {
            if (text.Equals(null))
            {
                Message = $"The ${variable} variable is undefined";
                Success = false;
            }
            else if (text.Length < min)
            {
                Message = $"The ${variable} variable is less than ${min}";
                Success = false;
            }
            else if (text.Length > max)
            {
                Message = $"The ${variable} variable is greater than ${max}";
                Success = false;
            }
            else
            {
                Success = true;
            }
        }

        public void Int(int min, int max, int number, string variable)
        {
            if (number.Equals(null))
            {
                Message = $"The ${variable} variable is undefined";
                Success = false;
            }
            else if (number < min)
            {
                Message = $"The ${variable} variable is less than ${min}";
                Success = false;
            }
            else if (number > max)
            {
                Message = $"The ${variable} variable is greater than ${max}";
                Success = false;
            }
            else
            {
                Success = true;
            }
        }

        public void Int(int min, int number, string variable)
        {
            if (number.Equals(null))
            {
                Message = $"The ${variable} variable is undefined";
                Success = false;
            }
            else if (number < min)
            {
                Message = $"The ${variable} variable is less than ${min}";
                Success = false;
            }
            else
            {
                Success = true;
            }
        }


    }
}
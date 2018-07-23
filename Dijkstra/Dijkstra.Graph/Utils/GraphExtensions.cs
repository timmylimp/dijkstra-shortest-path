using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace Dijkstra.Graph.Utils
{
    public static class GraphExtensions
    {
        public static bool TryValidate<T>(this T item, out List<ValidationResult> validationResults)
        {
            var context = new ValidationContext(item, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(item, context, validationResults);
            return isValid;
        }

        public static string ToFlatternMessage(this IEnumerable<ValidationResult> validationResults)
        {
            var message = new StringBuilder();

            foreach (var validationResult in validationResults)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    message.Append(String.Format("{0}, ", memberName));
                }
                if (message.Length >= 0)
                    message.Remove(message.Length - 2, 2);
                message.Append(" : ");
                message.AppendLine(validationResult.ErrorMessage);
            }

            return message.ToString();
        }
    }
}

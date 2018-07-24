using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace Dijkstra.Graph.Utils
{
    public static class GraphExtensions
    {
        /// <summary>
        /// Validate the class with DataAnnotation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="validationResults">Validate result output</param>
        /// <returns>True if valid. Otherwise false.</returns>
        public static bool TryValidate<T>(this T item, out List<ValidationResult> validationResults)
        {
            var context = new ValidationContext(item, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(item, context, validationResults, true);
            return isValid;
        }

        /// <summary>
        /// Make collection of ValidationResult easier to read.
        /// </summary>
        /// <param name="validationResults"></param>
        /// <returns>String describe all invalid result.</returns>
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

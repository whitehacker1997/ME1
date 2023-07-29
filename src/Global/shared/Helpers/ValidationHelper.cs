using Microsoft.AspNetCore.Mvc.ModelBinding;
using StatusGeneric;
using System.Reflection;

namespace Global
{
    public static class ValidationHelper
    {
        public static void CopyErrorToModelState<T>(this IStatusGeneric status, ModelStateDictionary modelState, T displayDto)
        {
            if (!status.HasErrors)
                return;
            var names = PropertyNamesInDto(displayDto);
            foreach (var error in status.Errors.Select(x => x.ErrorResult))
            {
                if (!error.MemberNames.Any())
                    modelState.AddModelError("", error.ErrorMessage);
                else
                    foreach (var errorKeyName in error.MemberNames)
                        modelState.AddModelError(
                            (names.Any(x => x == errorKeyName) ? errorKeyName : ""),
                            error.ErrorMessage
                            );
            }
        }
        public static void CopyErrorsToModelState(this IStatusGeneric status, ModelStateDictionary modelState)
        {
            if (!status.HasErrors) return;

            foreach (var error in status.Errors)
            {
                if (error.ErrorResult.MemberNames.Count() == 1)
                    modelState.AddModelError(error.ErrorResult.MemberNames.First(), error.ToString());
                else
                    modelState.AddModelError("", error.ToString());
            }
        }
        private static IList<string> PropertyNamesInDto<T>(T objectToCheck)
        {
            return objectToCheck!
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name)
                .ToList();
        }
    }
}

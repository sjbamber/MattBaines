using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Routing;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace MattBaines.Helpers
{
    public static class ExtensionMethods
    {
        public static string ToString<T>(this ICollection<T> l, string separator)
        {
            return String.Join(separator, l.Select(i => i.ToString()).ToArray());
        }

        public static bool HasAnyRole(this IPrincipal user, params string[] roles)
        {
            return roles.Any(user.IsInRole);
        }
    }

    public static class ValidationExtension
    {
        public static bool IsValid<T>(this T model) where T : class
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults.Count == 0;
        }
    }

    public static class JsonExtensions
    {
        public static string ToJson(this Object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
    }

    public static class EnumDropDownList
    {
        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "Any", Value = "" } };

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = HtmlHelpers.SplitCamelCase(GetEnumDescription(value)),
                                                    Value = value.ToString(),
                                                    Selected = value.Equals(metadata.Model)
                                                };

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }
}
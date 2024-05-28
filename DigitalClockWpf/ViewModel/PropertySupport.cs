//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System.Linq.Expressions;
using System.Reflection;

namespace DigitalClockWpf.ViewModel
{
    ///<summary>
    /// Provides support for extracting property information based on a property expression.
    ///</summary>
    public static class PropertySupport
    {
        /// <summary>
        /// Extracts the property name from a property expression.
        /// </summary>
        /// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
        /// <param name="propertyExpression">The property expression (e.g. p => p.PropertyName)</param>
        /// <returns>The name of the property.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="propertyExpression"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the expression is:<br/>
        ///     Not a <see cref="MemberExpression"/><br/>
        ///     The <see cref="MemberExpression"/> does not represent a property.<br/>
        ///     Or, the property is static.
        /// </exception>
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            if (propertyExpression.Body is not MemberExpression memberExpression)
            {
                throw new ArgumentException("Resources.PropertySupport_NotMemberAccessExpression_Exception", nameof(propertyExpression));
            }

            var property = memberExpression.Member as PropertyInfo ?? throw new ArgumentException("Resources.PropertySupport_ExpressionNotProperty_Exception", nameof(propertyExpression));
            var getMethod = property.GetGetMethod(true);
            ArgumentNullException.ThrowIfNull(getMethod);
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("Resources.PropertySupport_StaticExpression_Exception", nameof(propertyExpression));
            }

            return memberExpression.Member.Name;
        }
    }
}

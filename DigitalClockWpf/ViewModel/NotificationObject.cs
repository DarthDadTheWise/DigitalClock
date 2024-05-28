using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DigitalClockWpf.ViewModel
{
    /// <summary>
    ///     Base class for items that support property notification.
    /// </summary>
    /// <remarks>
    ///     This class provides basic support for implementing the <see cref="INotifyPropertyChanged" /> interface and for
    ///     marshalling execution to the UI thread.
    /// </remarks>
    public abstract class NotificationObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(storage, value)) return false;

            RaisePropertyChanging(propertyName);
            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        ///     Occurs when a property value is changing.
        /// </summary>
        public event PropertyChangingEventHandler? PropertyChanging;

        /// <summary>
        ///     Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Provided to allow a subclass to respond to a property changing without connecting to the event handler.
        /// </summary>
        protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
        {
        }

        /// <summary>
        ///     Provided to allow a subclass to respond to a property change without connecting to the event handler.
        /// </summary>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
        }


        /// <summary>
        ///     Raises this object's PropertyChanging event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        //[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise an event")]
        protected void RaisePropertyChanging(string? propertyName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);
            VerifyPropertyName(propertyName);

            var e = new PropertyChangingEventArgs(propertyName);
            OnPropertyChanging(e);

            PropertyChanging?.Invoke(this, e);
        }

        /// <summary>
        ///     Raises this object's PropertyChanging event.
        /// </summary>
        /// <typeparam name="T">The type of the property that has a new value</typeparam>
        /// <param name="propertyExpression">A Lambda expression representing the property that has a new value.</param>
        //[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise an event")]
        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Cannot change the signature")]
        protected virtual void RaisePropertyChanging<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            RaisePropertyChanging(propertyName);
        }

        /// <summary>
        ///     Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void RaisePropertyChanged(string? propertyName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);
            VerifyPropertyName(propertyName);

            var e = new PropertyChangedEventArgs(propertyName);
            OnPropertyChanged(e);

            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        ///     Raises this object's PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that has a new value</typeparam>
        /// <param name="propertyExpression">A Lambda expression representing the property that has a new value.</param>
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            RaisePropertyChanged(propertyName);
        }

        #region Debugging Aides

        /// <summary>
        ///     Warns the developer if this object does not have
        ///     a public property with the specified name. This
        ///     method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        internal void VerifyPropertyName(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] != null) return;

            var message = "Invalid property name: " + propertyName;
            Trace.TraceError(message);
            Debug.Fail(message);
        }

        #endregion Debugging Aides
    }
}

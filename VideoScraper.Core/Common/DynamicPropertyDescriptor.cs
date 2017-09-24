namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.ComponentModel;
	#endregion

	/// <summary>
	/// Delegate DynamicGetValue
	/// </summary>
	/// <param name="component">The component.</param>
	/// <returns>System.Object.</returns>
	public delegate object DynamicGetValue(object component);

	/// <summary>
	/// Delegate DynamicSetValue
	/// </summary>
	/// <param name="component">The component.</param>
	/// <param name="newValue">The new value.</param>
	public delegate void DynamicSetValue(object component, object newValue);

	/// <summary>
	/// Class DynamicPropertyDescriptor.
	/// </summary>
	public class DynamicPropertyDescriptor
		: PropertyDescriptor {
		private readonly DynamicGetValue _getDelegate;
		private readonly DynamicSetValue _setDelegate;

		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicPropertyDescriptor" /> class.
		/// </summary>
		/// <param name="componentType">Type of the component.</param>
		/// <param name="name">The name.</param>
		/// <param name="attributes">The attributes.</param>
		/// <param name="propertyType">Type of the property.</param>
		/// <param name="getDelegate">The get delegate.</param>
		/// <param name="setDelegate">The set delegate.</param>
		public DynamicPropertyDescriptor(Type componentType, string name, Attribute[] attributes, Type propertyType, DynamicGetValue getDelegate, DynamicSetValue setDelegate)
			: base(name, attributes) {
			ComponentType = componentType;
			PropertyType = propertyType;
			_getDelegate = getDelegate;
			_setDelegate = setDelegate;
		}

		/// <summary>
		/// When overridden in a derived class, returns whether resetting an object changes its value.
		/// </summary>
		/// <param name="component">The component to test for reset capability.</param>
		/// <returns>true if resetting the component changes its value; otherwise, false.</returns>
		public override bool CanResetValue(object component) {
			return false;
		}

		/// <summary>
		/// When overridden in a derived class, gets the type of the component this property is bound to.
		/// </summary>
		/// <value>The type of the component.</value>
		public override Type ComponentType { get; }

		/// <summary>
		/// When overridden in a derived class, gets the current value of the property on a component.
		/// </summary>
		/// <param name="component">The component with the property for which to retrieve the value.</param>
		/// <returns>The value of a property for a given component.</returns>
		public override object GetValue(object component) {
			return _getDelegate(component);
		}

		/// <summary>
		/// When overridden in a derived class, gets a value indicating whether this property is read-only.
		/// </summary>
		/// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
		public override bool IsReadOnly {
			get { return _setDelegate == null; }
		}

		/// <summary>
		/// When overridden in a derived class, gets the type of the property.
		/// </summary>
		/// <value>The type of the property.</value>
		public override Type PropertyType { get; }

		/// <summary>
		/// When overridden in a derived class, resets the value for this property of the component to the default value.
		/// </summary>
		/// <param name="component">The component with the property value that is to be reset to the default value.</param>
		public override void ResetValue(object component) {
		}

		/// <summary>
		/// When overridden in a derived class, sets the value of the component to a different value.
		/// </summary>
		/// <param name="component">The component with the property value that is to be set.</param>
		/// <param name="value">The new value.</param>
		public override void SetValue(object component, object value) {
			_setDelegate(component, value);
		}

		/// <summary>
		/// When overridden in a derived class, determines a value indicating whether the value of this property needs to be persisted.
		/// </summary>
		/// <param name="component">The component with the property to be examined for persistence.</param>
		/// <returns>true if the property should be persisted; otherwise, false.</returns>
		public override bool ShouldSerializeValue(object component) {
			return true;
		}

	}

}

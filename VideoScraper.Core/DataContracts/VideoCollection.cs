namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.Serialization;
	using Common;

	#endregion

	[CollectionDataContract]
	[Serializable]
	public class VideoCollection<TVideo>
		: BindingList<TVideo>, ITypedList
		where TVideo : Video {

		private PropertyDescriptorCollection _properties;

		#region Methods

		/// <summary>
		/// Adds the range.
		/// </summary>
		/// <param name="videos">The videos.</param>
		public void AddRange(IEnumerable<TVideo> videos) {
			videos.ToList().ForEach(video => this.Add(video));
		}

		/// <summary>
		/// Returns a <see cref="PropertyDescriptorCollection" /> that contains property names for our standard <see cref="MappedAccountLine" /> properties and the
		/// keys for the name/value pairs in <see cref="MappedAccountLine.AccountAttributes" /> that are required or defined by the user.
		/// </summary>
		/// <param name="properties">The property information for actual properties that can be bound and edited.</param>
		/// <param name="attributeNames">The key names for all required and dynamic name/value pairs in <see cref="MappedAccountLine.AccountAttributes" />.</param>
		/// <returns>A <see cref="PropertyDescriptorCollection" /> that contains information necessary for binding real and virtual properties.</returns>
		public PropertyDescriptorCollection GetView(List<PropertyInfo> properties) {
			var propertyDescriptors = new List<PropertyDescriptor>();

			foreach (var property in properties) {
				var customAttributes = property.GetCustomAttributes(true).Cast<Attribute>();

				propertyDescriptors.Add(
					new DynamicPropertyDescriptor(
						typeof(TVideo),
						property.Name,
						customAttributes.ToArray<Attribute>(),
						property.PropertyType,
						video => property.GetValue(video, null),
						delegate (object video, object newValue) {
							property.SetValue(video, newValue, null);
						}
					));
			}
			return new PropertyDescriptorCollection(propertyDescriptors.ToArray<PropertyDescriptor>());
		}

		/// <summary>
		/// Gets the property names.
		/// </summary>
		/// <returns>List&lt;System.String&gt;.</returns>
		public List<PropertyInfo> GetVisibleProperties() {
			return typeof(TVideo)
				.GetProperties()
				.Where(property => property.GetCustomAttributes(typeof(DataGridViewDisplayAttribute), true).FirstOrDefault() != null)
				.OrderBy(property => (property.GetCustomAttributes(typeof(DataGridViewDisplayAttribute), true).FirstOrDefault() as DataGridViewDisplayAttribute)?.Index ?? 0)
				.ToList();
		}

		#endregion

		#region ITypedList Members

		/// <summary>
		/// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the properties on each item used to bind data.
		/// </summary>
		/// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor" /> objects to find in the collection as bindable. This can be null.</param>
		/// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> that represents the properties on each item used to bind data.</returns>
		public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) {
			return _properties ?? (
				_properties = this.GetView(
					this.GetVisibleProperties()
					)
				);
		}

		/// <summary>
		/// Returns the name of the list.
		/// </summary>
		/// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor" /> objects, for which the list name is returned. This can be null.</param>
		/// <returns>The name of the list.</returns>
		public string GetListName(PropertyDescriptor[] listAccessors) {
			return typeof(TVideo).Name;
		}

		#endregion

	}

}

﻿
using Mauve.Serialization;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods that are applicable to all types utilizing generics for type safety.
    /// </summary>
    public static class GenericExtensions
    {

        #region Public Methods

        /// <summary>
        /// Serializes the current state of the specified input utilizing the specified <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data to be serialized.</typeparam>
        /// <param name="input">The data to be serialized.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be utilized for serialization.</param>
        /// <returns>Returns the input data serialized using the specified <see cref="SerializationMethod"/>.</returns>
        public static string Serialize<T>(this T input, SerializationMethod serializationMethod)
        {
            SerializationProvider serializationProvider;
            switch (serializationMethod)
            {
                case SerializationMethod.Binary: serializationProvider = new BinarySerializationProvider(); break;
                case SerializationMethod.Xml: serializationProvider = new XmlSerializationProvider(); break;
                case SerializationMethod.Json: serializationProvider = new JsonSerializationProvider(); break;
                case SerializationMethod.Yaml: serializationProvider = new YamlSerializationProvider(); break;
                default: serializationProvider = new RawSerializationProvider(); break;
            }

            return serializationProvider.Serialize(input);
        }

        #endregion

    }
}

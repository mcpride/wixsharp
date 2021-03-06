using System.Collections.Generic;
using System.Xml.Linq;

namespace WixSharp
{
    /// <summary>
    /// This type is a container for the all information needed by the implementer of <see cref="WixSharp.IGenericEntity"/>
    /// </summary>
    public class ProcessingContext
    {
        /// <summary>
        /// Wix# project being compiled.
        /// </summary>
        public Project Project;

        /// <summary>
        /// Wix# project member that hosts (contains) user defined WiX entity being compiled/processed.
        /// </summary>
        public WixEntity Parent;

        /// <summary>
        /// XML element already generated by Wix# for the <see cref="WixSharp.ProcessingContext.Parent"/>.
        /// </summary>
        public XElement XParent;

        /// <summary>
        /// Map of features and their associated components. The map contains pairs of Features and their component IDs.
        /// <para>
        /// If <see cref="WixSharp.IGenericEntity"/> needs to create a component it can immediately 
        /// associate this component with either existing feature in the map or add a new map entry.
        /// </para>
        /// </summary>
        public Dictionary<Feature, List<string>> FeatureComponents;
    }

    /// <summary>
    /// An interface for the external user defined WiX entities (e.g. new WiX extensions) to be integrated with Wix# compiler.
    /// </summary>
    public interface IGenericEntity
    {
        /// <summary>
        /// Adds itself as an XML content into the WiX source being generated from the <see cref="WixSharp.Project"/>.
        /// See 'Wix#/samples/Extensions' sample for the details on how to implement this interface correctly.
        /// </summary>
        /// <param name="context">The context.</param>
        void Process(ProcessingContext context);
    }
}
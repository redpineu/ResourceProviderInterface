using System.Collections.Generic;

namespace Babylon.ResourcesProvider
{
    /// <summary>
    /// Interface to be implemented by classes providing string resources for translation.
    /// </summary>
    public interface IResourcesProvider
    {
        /// <summary>
        /// Imports the resource strings to be translated into the Babylon.NET project
        /// </summary>
        /// <param name="projectName">Name of the project the resources will be imported into</param>
        /// <param name="projectLocale">The project invariant locale</param>
        /// <returns>The imported strings</returns>
        ICollection<StringResource> ImportResourceStrings(string projectName, string projectLocale);

        /// <summary>
        /// Exports the resource strings from the Babylon.NET project
        /// </summary>
        /// <param name="projectName">Name of the project the resources will be exported from</param>
        /// <param name="projectLocale">The project invariant locale</param>
        /// <param name="resourceStrings">The strings to be exported</param>
        /// <param name="resultDelegate">Callback delegate to provide progress information and storage operation results</param>
        void ExportResourceStrings(string projectName, string projectLocale, IReadOnlyCollection<string> localesToExport, ICollection<StringResource> resourceStrings, ResourceStorageOperationResultDelegate resultDelegate);

        /// <summary>
        /// The name of the resource provider. Use this to indicate what type of files/storage the provider is working with.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Detailed description of how the provider works.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Path to the solution file. Set by Babylon.NET. Use this in the provider to build absolute paths if the storage location is relative to the solution.
        /// </summary>
        string SolutionPath { get; set; }

        /// <summary>
        /// The storage location where the string resources are read and written to are located. This generally is a file or a base directory but could also be a connection string to the database.
        /// </summary>
        string StorageLocation { get; set; }

        /// <summary>
        /// Text to be displayed to the user when the storage location should be spefied: e.g. "Please select the base directory".
        /// </summary>
        string StorageLocationUserText { get; }

        /// <summary>
        /// Indicates what kind of storage is used for the storage location. This will determine whether Babylon.NET displays a file selection or directory selection control or a simple textx control.
        /// </summary>
        StorageType StorageType { get; }
    }
}

# Interface definition for the Resource Provider plug-in interface for Babylon

The easiest way to develop a new ResourcesProvider is to download the source code from an existing ResourcesProvider and modify it to your needs. To implement the IResourcesProvider interface reference the ResourceProvider.dll included in every Babylon.NET installation. The ResourcesProvider assembly also defines the StringResource class which represents one string and all its translations.

To install a ResourcesProvider simple copy the assembly to the ResourceProviders subfolder of the Babylon.NET installation folder along with all assemblies and configuration files needed. 
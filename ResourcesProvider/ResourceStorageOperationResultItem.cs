

namespace Babylon.ResourcesProvider
{
    /// <summary>
    /// Represents the result of a resource storage operation in an operation involving several storage locations
    /// </summary>
    public class ResourceStorageOperationResultItem
    {
        public ResourceStorageOperationResult Result { get; set; }
        public string Message { get; set; }
        public string StorageLocation { get; set; }
        public string ProjectName { get; set; }

        public ResourceStorageOperationResultItem(string storageLocation)
        {
            Result = ResourceStorageOperationResult.OK;
            Message = "";
            StorageLocation = storageLocation;
        }
    }
}

using UnityEngine;
namespace ToolFolder
{
    [CreateAssetMenu(fileName = "Folder Structure", menuName = "ToolFolder/Folder Structure", order = 1)]
    public class SCO_FolderStructure : ScriptableObject
    {
        public FolderStructureBase[] folderStructures = null;
    }
}


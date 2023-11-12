using UnityEditor;
using UnityEngine;

namespace ToolFolder  
{
    public class EditorCreatorFolder : EditorWindow
    {
        public SCO_FolderStructure folderStruct;
        [MenuItem("EditorTool/Create Folder Structure")]
        public static void ShowWindow()
        {
            GetWindow<EditorCreatorFolder>("Create Folder Structure");
        }
        private void OnGUI()
        {
            Vector2 scrollPosition = Vector2.zero;
            GUILayout.Label("Structure Folder", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Folder Structure File:", EditorStyles.boldLabel);
            folderStruct = EditorGUILayout.ObjectField(folderStruct, typeof(SCO_FolderStructure), true) as SCO_FolderStructure;
            GUILayout.EndHorizontal();
            EditorGUILayout.Space(3);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true,GUILayout.MinHeight(100));
            EditorGUILayout.LabelField("Folder Structure Preview");
            ShowStructurePreview(folderStruct);
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
            EditorGUILayout.Space(10);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Create Folders"))
            {
                if (folderStruct != null)
                {
                    CreateStructure();
                }
                else
                {
                    Debug.LogWarning("Cannot create folders without a Folder Structure File");
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        private void CreateStructure()
        {
            if (folderStruct != null && folderStruct.folderStructures.Length > 0)
            {
                foreach (var folder in folderStruct.folderStructures)
                {
                    string folderPath = "Assets/" + folder.nameParent;
                    if (!string.IsNullOrEmpty(folder.nameParent))
                    {
                        if (!AssetDatabase.IsValidFolder(folderPath))
                        {
                            AssetDatabase.CreateFolder("Assets", folder.nameParent);
                        }
                    }
                    if (folder.childrenFolder.Length > 0)
                    {
                        foreach (var childFolder in folder.childrenFolder)
                        {
                            string folderChildrenPath = folderPath + "/" + childFolder;
                            if (!string.IsNullOrEmpty(childFolder))
                            {
                                if (!AssetDatabase.IsValidFolder(folderChildrenPath))
                                {
                                    AssetDatabase.CreateFolder(folderPath, childFolder);
                                }
                            }
                        }
                    }
                }
            }

        }

        private void ShowStructurePreview(SCO_FolderStructure structure)
        {
            if (structure != null && structure.folderStructures.Length > 0)
            {
                foreach (var folderPreview in structure.folderStructures)
                {
                    string folderPath = "Assets/" + folderPreview.nameParent;

                    if (!string.IsNullOrEmpty(folderPreview.nameParent))
                    {
                        if (!AssetDatabase.IsValidFolder(folderPath))
                        {
                            EditorGUILayout.LabelField($"-{folderPreview.nameParent}");
                        }
                        else
                        {
                            EditorGUILayout.LabelField($"-{folderPreview.nameParent} (The folder already exists)", EditorStyles.boldLabel);
                        }
                    }

                    EditorGUI.indentLevel++;

                    if (folderPreview.childrenFolder.Length > 0)
                    {
                        foreach (var childPreview in folderPreview.childrenFolder)
                        {
                            string folderChildrenPath = folderPath + "/" + childPreview;

                            if (!string.IsNullOrEmpty(childPreview))
                            {
                                if (!AssetDatabase.IsValidFolder(folderChildrenPath))
                                {
                                    EditorGUILayout.LabelField($"-{childPreview}");
                                }
                                else
                                {
                                    EditorGUILayout.LabelField($"-{childPreview} (The folder already exists)", EditorStyles.boldLabel);
                                }
                            }
                        }
                    }
                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                EditorGUILayout.LabelField("No Folder Structure available");
            }
        }
    }
}

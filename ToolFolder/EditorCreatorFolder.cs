using UnityEditor;
using UnityEngine;

namespace ToolFolder  
{
    public class EditorCreatorFolder : EditorWindow
    {
        public SCO_FolderStructure folderStruct;
        private Vector2 scrollPosition;

        [MenuItem("EditorTool/Create Folder Structure")]
        public static void ShowWindow()
        {
            GetWindow<EditorCreatorFolder>("Create Folder Structure");
        }
        private void OnGUI()
        {
            using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollView.scrollPosition;

                GUILayout.Label("Structure Folder", EditorStyles.boldLabel);

                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Folder Structure File:", EditorStyles.boldLabel);
                folderStruct = EditorGUILayout.ObjectField(folderStruct, typeof(SCO_FolderStructure), true) as SCO_FolderStructure;
                GUILayout.EndHorizontal();
                EditorGUILayout.Space(3);

                GUILayout.BeginVertical(EditorStyles.helpBox);

                EditorGUILayout.LabelField("Folder Structure Preview");
                ShowStructurePreview(folderStruct);

                GUILayout.EndVertical();
                EditorGUILayout.Space(10);

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Create Folders", GUILayout.MinHeight(50)))
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
                GUILayout.EndHorizontal();
            }
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

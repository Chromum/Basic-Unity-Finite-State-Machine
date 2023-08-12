using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;

[CustomEditor(typeof(ReadMe))]
public class ReadMeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ReadMe readme = (ReadMe)target;

        if (readme != null)
        {
            string filePath = "Assets/AIPackage/Utils/Editor/ReadMe.xml"; // Modify the path accordingly

            if (File.Exists(filePath))
            {
                TextAsset xmlFile = AssetDatabase.LoadAssetAtPath<TextAsset>(filePath);

                if (xmlFile != null)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlFile.text);

                    XmlNode readmeNode = xmlDoc.SelectSingleNode("ReadMe");

                    if (readmeNode != null)
                    {
                        string readmeText = readmeNode.InnerText;
                        
                        // Display the README text without allowing editing
                        GUILayout.Label(readmeText, EditorStyles.textArea);
                    }
                }
            }
            else
            {
                EditorGUILayout.HelpBox("README XML file not found in the specified path.", MessageType.Warning);
            }
        }
    }
}
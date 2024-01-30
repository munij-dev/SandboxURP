using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class KeywordReplace : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset (string path) {
            path = path.Replace( ".meta", "" );
            int index = path.LastIndexOf( "." );
            if (index < 0)
                return;
     
            string file = path.Substring( index );
            if (file != ".cs" && file != ".js" && file != ".boo")
                return;
     
            index = Application.dataPath.LastIndexOf( "Assets" );
            path = Application.dataPath.Substring( 0, index ) + path;
            if (!System.IO.File.Exists( path ))
                return;
     
            string fileContent = System.IO.File.ReadAllText( path );
            fileContent = fileContent.Replace( "#AUTHOR#", PlayerSettings.companyName );
            fileContent = fileContent.Replace( "#PROJECT_NAME#", PlayerSettings.productName );
            fileContent = fileContent.Replace("#CREATION_DATE#", System.DateTime.Now + "");
     
            System.IO.File.WriteAllText( path, fileContent );
            AssetDatabase.Refresh();
        }
    }
}

using System.IO;
using UnityEditor;
using UnityEngine;

namespace QuixoticTools
{
	public static class QuixoticTools_Utilities
	{
		// ================================================================ «» ================================================================ //

		#region | JSON «» SO |

		public static void SaveSOToJSON( ScriptableObject so )
		{

			string path = AssetDatabase.GetAssetPath( MonoScript.FromScriptableObject( so ) );
			if ( path.Contains( "." ) )
			{
				int index = path.LastIndexOf( "/" );
				path = path.Substring( 0, index );
			}

			File.WriteAllText( path + $"/{so.name}_RAW.JSON", JsonUtility.ToJson( so, true ) );
			AssetDatabase.Refresh();
		}

		public static void LoadSOFromJSON( ScriptableObject so )
		{
			string path = AssetDatabase.GetAssetPath( so );
			if ( path.Contains( "." ) )
			{
				int index = path.LastIndexOf( "/" );
				path = path.Substring( 0, index );
			}

			string jsonData = File.ReadAllText( path + $"/{so.name}_RAW.JSON" );
			JsonUtility.FromJsonOverwrite( jsonData, so );
		}

		#endregion | JSON «» SO |

		// ================================================================ «» ================================================================ //

		public static string GetAssetFolderPath()
		{
			string path = AssetDatabase.GUIDToAssetPath( Selection.assetGUIDs[ 0 ] );
			if ( path.Contains( "." ) )
			{
				int index = path.LastIndexOf( "/" );
				path = path.Substring( 0, index );
			}
			return path;
		}

		// ================================================================ «» ================================================================ //
	}
}
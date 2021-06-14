using Assets.Scripts.Utils;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.UI
{
    public class RebindUISaveLoad : MonoBehaviour
    {
        /// <summary>
        /// The input asset to save
        /// </summary>
        public InputActionAsset inputAsset;

        public void OnEnable()
        {
            string rebinds = PlayerPrefs.GetString("controls");
            if (!string.IsNullOrEmpty(rebinds))
                inputAsset.LoadBindingOverridesFromJson(rebinds);
            /*if (File.Exists(FilesPath.jsonInputAsset))
            {
                string JSONDatas;
                StreamReader file = File.OpenText(FilesPath.jsonInputAsset);
                JSONDatas = file.ReadToEnd();
                file.Close();

                Debug.Log(JSONDatas);
                InputActionRebindingExtensions.LoadBindingOverridesFromJson(inputAsset, JSONDatas);
            }
            else
            {
                Debug.LogError($"Unable to find the Config file at {FilesPath.jsonInputAsset}");
            }*/
        }

        public void OnDisable()
        {
            string JSONDatas = inputAsset.SaveBindingOverridesAsJson();

            /*Debug.Log(JSONDatas);

            if (File.Exists(FilesPath.jsonInputAsset))
            { File.Delete(FilesPath.jsonInputAsset); }

            StreamWriter file = File.CreateText(FilesPath.jsonInputAsset);
            file.WriteLine(JSONDatas);
            file.Close();*/

            PlayerPrefs.SetString("controls", JSONDatas);
        }
    }
}
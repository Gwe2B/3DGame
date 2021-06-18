using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utils.Translate
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class TranslateTextMesh : MonoBehaviour
    {
        [SerializeField]
        private string m_Key = null;

        private void Start()
        {
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = Translation.Get(m_Key != string.Empty ? m_Key : text.text);
            Destroy(this);
        }
    }
}
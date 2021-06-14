using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utils.Translate
{
    [RequireComponent(typeof(Text))]
    public sealed class TranslateText : MonoBehaviour
    {
        [SerializeField]
        private string m_Key = null;

        private void Start()
        {
            Text text = GetComponent<Text>();
            text.text = Translation.Get(m_Key != string.Empty ? m_Key : text.text);
            Destroy(this);
        }
    }
}
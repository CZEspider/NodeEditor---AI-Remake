using NodeEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Nodes/Audio")]
    public class DialogAudioNode : ExecutableNode
    {

        private bool WasPlayed = false;

        public override void DrawCurve(BaseNode node)
        {
        }

        //OBECNÁ ČÁST VZHLEDU!
        public override void DrawWindow(BaseNode b)
        {
            GUIStyle s = new GUIStyle();
            s.fontSize = 12;
            s.richText = true;
            s.alignment = TextAnchor.UpperCenter;
            s.padding.top = 0;
            s.normal.textColor = GUIStylizer.Colors.BLACK;

            DialogEditor.GetEGLLable("Audio clip:", s);
            b.dialogAudioClip = EditorGUILayout.ObjectField(b.dialogAudioClip, typeof(AudioClip), false) as AudioClip;
            b.DialogGraph.SetDirty();
        }

        public override void Execute(BaseNode b)
        {
            if(!WasPlayed)
            {
                PlaySound(b.dialogAudioClip);
                WasPlayed = true;
            }
        }

        public void PlaySound(AudioClip audio)
        {
            Debug.Log("PlayingSound");
            AudioSource AudioPlayer = DialogManager.Instance.GetComponentInParent<AudioSource>();
            AudioPlayer.clip = audio;
            AudioPlayer.PlayOneShot(audio);
        }
    }
}

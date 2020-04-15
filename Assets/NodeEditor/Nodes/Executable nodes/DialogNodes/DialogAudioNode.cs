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

            if (DialogManager.Instance.AudioPlayer.clip != b.dialogAudioClip)
                DialogManager.Instance.AudioPlayer.Stop();
            DialogManager.Instance.AudioPlayer.clip = b.dialogAudioClip;

            //IF zakázáno, protože po dohrání zvuku se spustí znovu!!//

            //if (DialogManager.Instance.AudioPlayer.clip.loadState == AudioDataLoadState.Loaded && DialogManager.Instance.AudioPlayer.clip == b.dialogAudioClip && DialogManager.Instance.AudioPlayer.isPlaying == false)
            //{
            //    DialogManager.Instance.AudioPlayer.Play();
            //}

            //IF zakázáno, protože po dohrání zvuku se spustí znovu!!//
        }
    }
}

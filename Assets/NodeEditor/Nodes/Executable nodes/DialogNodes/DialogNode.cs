﻿using NodeEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Nodes/Dialog")]
    public class DialogNode : ExecutableNode
    {
        public override void DrawCurve(BaseNode node)
        {
        }

        public override void DrawWindow(BaseNode b)
        {
            DialogEditor.GetEGLLable("Audio clip:", GUIStyle.none);
            b.dialogAudioClip = EditorGUILayout.ObjectField(b.dialogAudioClip, typeof(AudioClip), false) as AudioClip;

#pragma warning disable CS0618 // Typ nebo člen je zastaralý.
            b.DialogGraph.SetDirty();
#pragma warning restore CS0618 // Typ nebo člen je zastaralý.

        }

        public override void Execute(BaseNode b)
        {
            if (b.dialogAudioClip != null)
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class okngDialog : MonoBehaviour
{

    public enum DialogResult
    {
        OK,
        Cancel,
    }
    
    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }
    
    // OKボタンが押されたとき
    public bool OnOk()
    {
        this.FixDialog?.Invoke(DialogResult.OK);
        Destroy(this.gameObject);
        return true;
    }
    
    // Cancelボタンが押されたとき
    public bool OnCancel()
    {
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
        return false;
    }
}

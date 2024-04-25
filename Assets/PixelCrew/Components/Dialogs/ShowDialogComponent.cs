using System;
using PixelCrew.Model.Data;
using PixelCrew.Model.Definitions;
using PixelCrew.UI.Hud.Dialogs;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        [SerializeField] private DialogData _bound;
        [SerializeField] private DialogDef _external;

        [SerializeField] private UnityEvent _onCopmpleted;
        
        private DialogBoxController _dialogBox;
        public void Show()
        {
            if (_dialogBox == null)
                _dialogBox = FindObjectOfType<DialogBoxController>();
            
            _dialogBox.ShowDialog(Data);
        }

        public void Show(DialogDef def)
        {
            _external = def;
            Show();
        }

        public void OnCompleted()
        {
            if(_external.IsLast)
                _onCopmpleted?.Invoke();
        }
        public DialogData Data
        {
            get
            {
                switch (_mode)
                {
                    case Mode.Bound:
                        return _bound;
                    case Mode.External:
                        return _external.Data;
                    default:
                        throw new ArgumentException();
                }
            }
        }

        public enum Mode
        {
            Bound,
            External
        }
    }
    
}
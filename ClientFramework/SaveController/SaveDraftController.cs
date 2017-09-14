using System;

namespace ClientFramework
{
    internal sealed class SaveController : ISaveDraftController
    {
        public SaveController(Action<object> saveDraft, Func<object, SaveResult> save, Predicate<object> canSave)
        {
            SaveDraft = saveDraft;
            Save = save;
            CanSave = canSave;
        }

        public Action<object> SaveDraft { get; }

        public Func<object, SaveResult> Save { get; }

        public Predicate<object> CanSave { get; }

        public event EventHandler CanSaveChanged;

        public void RaiseCanSaveChange()
        {
            CanSaveChanged?.Invoke(this, EventArgs.Empty);
        }   
    }
}

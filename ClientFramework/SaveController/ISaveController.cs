using System;

namespace ClientFramework
{
    public interface ISaveController
    {
        Func<object, SaveResult> Save { get; } 

        Predicate<object> CanSave { get; }
       
        event EventHandler CanSaveChanged;

        void RaiseCanSaveChange();
    }
}

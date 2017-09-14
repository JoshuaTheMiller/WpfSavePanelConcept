using System;

namespace ClientFramework
{
    public interface ISaveDraftController : ISaveController
    {
        Action<object> SaveDraft { get; } 
    }
}

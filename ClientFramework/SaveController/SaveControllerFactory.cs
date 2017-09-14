using System;

namespace ClientFramework
{
    public static class SaveControllerFactory
    {
        public static ISaveController Create(Func<object, SaveResult> saveDelegate)
        {
            return new SaveController(DoNothing, saveDelegate, AlwaysCanSave);
        }

        public static ISaveController Create(Func<object, SaveResult> saveDelegate, Predicate<object> canSaveDelegate)
        {
            return new SaveController(DoNothing, saveDelegate, canSaveDelegate);
        }

        public static ISaveDraftController Create(Func<object, SaveResult> saveDelegate, Action<object> draftSaveDelegate)
        {
            return new SaveController(draftSaveDelegate, saveDelegate, AlwaysCanSave);
        }

        public static ISaveDraftController Create(Func<object, SaveResult> saveDelegate, Action<object> draftSaveDelegate, Predicate<object> canSaveDelegate)
        {
            return new SaveController(draftSaveDelegate, saveDelegate, canSaveDelegate);
        }

        public static ISaveDraftController Empty()
        {
            return new SaveController(DoNothing, obj => SaveResult.CreateSucceeded(), AlwaysCanSave);
        }

        private static bool AlwaysCanSave(object obj)
        {
            return true;
        }

        private static void DoNothing(object obj)
        {
        }
    }
}

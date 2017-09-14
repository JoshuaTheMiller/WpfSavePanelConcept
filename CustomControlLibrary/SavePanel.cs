using ClientFramework;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControlLibrary
{
    public class SavePanel : ContentControl
    {
        private bool canSaveDraft = false;

        static SavePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SavePanel), new FrameworkPropertyMetadata(typeof(SavePanel)));
        }

        public ISaveController SaveController
        {
            get { return (ISaveController)GetValue(SaveControllerProperty); }
            set { SetValue(SaveControllerProperty, value); }
        }
        
        public static readonly DependencyProperty SaveControllerProperty =
            DependencyProperty.Register("SaveController", typeof(ISaveController), typeof(SavePanel), new PropertyMetadata(SaveControllerFactory.Empty(), OnSaveControllerSet));

        public ICommand Save
        {
            get { return (ICommand)GetValue(SaveProperty); }
            set { SetValue(SaveProperty, value); }
        }
        
        public static readonly DependencyProperty SaveProperty =
            DependencyProperty.Register("Save", typeof(ICommand), typeof(SavePanel), new PropertyMetadata(OnSaveChanged));        

        public object SaveParameter
        {
            get { return (object)GetValue(SaveParameterProperty); }
            set { SetValue(SaveParameterProperty, value); }
        }
       
        public static readonly DependencyProperty SaveParameterProperty =
            DependencyProperty.Register("SaveParameter", typeof(object), typeof(SavePanel), new PropertyMetadata(null));

        /// <summary>
        /// In Milliseconds. 0 is treated as never automatically save a draft.
        /// </summary>
        public int AutoSaveDraftInterval
        {
            get { return (int)GetValue(AutoSaveDraftIntervalProperty); }
            set { SetValue(AutoSaveDraftIntervalProperty, value); }
        }
        
        public static readonly DependencyProperty AutoSaveDraftIntervalProperty =
            DependencyProperty.Register("AutoSaveDraftInterval", typeof(int), typeof(SavePanel), new PropertyMetadata(0));

        //TODO: make this readonly
        public ObservableCollection<SaveResult> SaveResults
        {
            get { return (ObservableCollection<SaveResult>)GetValue(SaveResultsProperty); }
            set { SetValue(SaveResultsProperty, value); }
        }
        
        public static readonly DependencyProperty SaveResultsProperty =
            DependencyProperty.Register("SaveResults", typeof(ObservableCollection<SaveResult>), typeof(SavePanel), new PropertyMetadata(new ObservableCollection<SaveResult>()));

        private static void OnSaveControllerSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var savePanel = (SavePanel)d;

            if(e.NewValue is ISaveDraftController)
            {
                savePanel.canSaveDraft = true;
            }
        }

        //TODO: this probably won't work, but it's late
        private static void OnSaveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var savePanel = (SavePanel)d;

            if(e.NewValue != null)
            {
                savePanel.Save = CommandFactory.Create(savePanel.OnSave);
            }           
        }

        private void OnSave(object obj)
        {
            var result = SaveController.Save(SaveParameter);
        }
    }
}

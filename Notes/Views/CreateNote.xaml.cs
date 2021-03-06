﻿using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Notes.ViewModels;

namespace Notes.Views
{
    public sealed partial class CreateNote : Page //, INotifyPropertyChanged


    {

        readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        public MainViewModel ViewModel => DataContext as MainViewModel;

        public CreateNote()
        {    
            this.InitializeComponent();

            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dispatcherTimer.Start();
            ((Application)Application.Current).OnBackRequested += OnOnBackRequested;
        }

        private void dispatcherTimer_Tick(object sender, object e)
        {
           
            BoxForTime.Text = DateTime.Now.ToString("dd-MM-yyyy / hh:mm:ss");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dispatcherTimer.Stop();
            ((Application)Application.Current).OnBackRequested -= OnOnBackRequested;
        }

        private void OnOnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            backRequestedEventArgs.Handled = true;
            ViewModel.CancelNewNote();
        }
    }
}

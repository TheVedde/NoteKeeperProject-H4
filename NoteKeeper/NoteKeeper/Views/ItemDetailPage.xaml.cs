using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKeeper.Models;
using NoteKeeper.ViewModels;
using System.Collections.Generic;
using NoteKeeper.Services;

namespace NoteKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public Note Note { get; set; }

        public IList<String> CourseList { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();
           
            BindingContext = Note;
            NoteCourse.BindingContext = this;
        }



        public ItemDetailPage()
        {
            InitializeComponent();
            InitializeData();
            BindingContext = Note;
            NoteCourse.BindingContext = this;
        }


        async void InitializeData()
        {
            var pluralsightDatastore = new MockPluralsightDataStore();
            CourseList = await pluralsightDatastore.GetCoursesAsync();

            Note = new Note { Heading = "Test Note", Text = "Text for the test note" };

        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Cancel option", "Cancel was selected", "Button 2", "Button 1");

        }

        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Save option", "Save was clicked", "Button 2", "Button 1");

        }
    }
}
using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }

        public IList<String> CourseList { get; set; }

        public String NoteHeading
        {
            get { return Note.Heading; }

            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }

        }

        public String NoteText
        {
            get { return Note.Text; }

            set
            {
                Note.Text = value;
                OnPropertyChanged();
            }
        }

        public String NoteCourse
        {
            get { return Note.Course; }

            set
            {
                Note.Course = value;
                OnPropertyChanged();

            }

        }


        public ItemDetailViewModel(Item item = null)
        {
           
            Title = item?.Text;
            InitializeCourseList();
            Note = Note ?? new Note
            {
                Heading = "Test note",
                Text = "Text for note in ViewModel",
                Course = CourseList[0]

            };
        }

        public ItemDetailViewModel(Note note)
        {
            Note = note;
        }

        async void InitializeCourseList()
        {

            CourseList = await PluralsightDataStore.GetCoursesAsync();

        }
    }
}

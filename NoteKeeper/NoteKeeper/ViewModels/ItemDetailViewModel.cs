using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }

        public IList<String> CourseList { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
           
            Title = item?.Text;
            InitializeCourseList();
            Note = new Note { Heading = "Test Note", Text = "Text for note in viewmodel", Course = CourseList[0] };
            
        }


        async void InitializeCourseList()
        {

            CourseList = await pluralsightDataStore.GetCoursesAsync();

        }
    }
}

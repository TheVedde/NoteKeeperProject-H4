using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NoteKeeper.Models;
using NoteKeeper.Views;

namespace NoteKeeper.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "saveNote", async (sender, note) => 
            {
                Notes.Add(note);
                await PluralsightDataStore.AddNoteAsync(note);
            
            });

            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "UpdateNote",
               async (sender, note) => {
                    // Update note in data store
                    await PluralsightDataStore.UpdateNoteAsync(note);
                    // Modifying a member (our note) within an ObservableCollection
                    //  does not automatically refresh data binding .. so explicitly
                    //  repopulate the collection
                    await ExecuteLoadItemsCommand();
               });

        }



        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notes.Clear();
                var notes = await PluralsightDataStore.GetNotesAsync();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
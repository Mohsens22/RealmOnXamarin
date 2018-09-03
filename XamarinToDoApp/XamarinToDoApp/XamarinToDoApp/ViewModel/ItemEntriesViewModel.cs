using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinToDoApp
{
    public class ItemEntriesViewModel
    {
        public ItemEntriesViewModel()
        {
            var credentials = Credentials.Nickname("ian", isAdmin: true);
            var user = Task.Run(() => User.LoginAsync(credentials, new Uri(Constants.AUTH_URL))).Result;
            var configuration = new FullSyncConfiguration(new Uri(Constants.REALM_URL), user);
            realm = Realm.GetInstance(configuration);
            Entries = realm.All<Item>();
            DeleteEntryCommand = new Command<Item>(DeleteEntry);
        }
        public IEnumerable<Item> Entries { get; private set; }

        public INavigation Navigation { get; set; }

        Realm realm;

        public ICommand DeleteEntryCommand { get; private set; }

        public ICommand AddEntryCommand { get; private set; }
        void DeleteEntry(Item entry) => realm.Write(() => realm.Remove(entry));
    }
}
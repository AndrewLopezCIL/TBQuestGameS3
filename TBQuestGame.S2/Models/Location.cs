using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
   public class Location : ObservableObject
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        private string locationMessage;

        public string LocationMessage
        {
            get { return locationMessage; }
            set { locationMessage = value; }
        }
        private string _locationWarningMessage;
        public string LocationWarningMessage
        {
            get { return _locationWarningMessage; }
            set { _locationWarningMessage = value; }
        }

        private bool _fightChance;

        public bool ChanceOfFight
        {
            get { return _fightChance; }
            set { _fightChance = value; }
        }

        private bool _multiAttackLocation;
        public bool MultiAttackLocation
        {
            get { return _multiAttackLocation; }
            set
            {
                _multiAttackLocation = value; OnPropertyChanged(nameof(MultiAttackLocation));
            }
        }
        private string _locationWarningImages;
        public string LocationWarningImage
        {
            get { return _locationWarningImages; }
            set
            {
                _locationWarningImages = value;
            }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private bool _accessible;

        public bool Accessible
        {   
            get { return _accessible; }
            set { _accessible = value; }
        }

        private bool _fightRoom;

        public bool BossFightRoom
        {
            get { return _fightRoom; }
            set { _fightRoom = value; }
        }

        private ObservableCollection<Item> _lootableItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> LootableItems
        {
            get { return _lootableItems; }
            set { _lootableItems = value; }
        }

        public static void enableControls(GameSessionView view)
        {
            view.North_Button.IsEnabled = true;
            view.East_Button.IsEnabled = true;
            view.South_Button.IsEnabled = true;
            view.West_Button.IsEnabled = true;
        }
        public static void disableControls(GameSessionView view)
        {
            view.North_Button.IsEnabled = false;
            view.East_Button.IsEnabled = false;
            view.West_Button.IsEnabled = false;
            view.South_Button.IsEnabled = false;
        }

      


    }
}

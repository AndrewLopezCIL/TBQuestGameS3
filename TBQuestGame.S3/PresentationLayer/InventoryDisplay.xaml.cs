using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame.Models.Items;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for InventoryDisplay.xaml
    /// </summary>
    public partial class InventoryDisplay : Window
    {
        GameSessionViewModel gsm;
        GameSessionView gsv;
        public int _LocationLootListItemSelected = 0;
        public int _PlayerInventoryItemSelected = 0;
        public InventoryDisplay(GameSessionViewModel gsm, GameSessionView GSV)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.gsm = gsm;
            this.gsv = GSV;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void LocationLootList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int item = 0; item < gsm.GameMap.CurrentLocation.LootableItems.Count; item++)
            {
                if (gsm.GameMap.CurrentLocation.LootableItems[item].HasListSelection == true)
                {
                    if (gsm.Player.Inventory.Count >= 1)
                    {

                        for (int obj = 0; obj < gsm.Player.Inventory.Count; obj++)
                        {
                        if (gsm.Player.Inventory[obj].Name == gsm.GameMap.CurrentLocation.LootableItems[item].Name && gsm.GameMap.CurrentLocation.LootableItems[item].SpecialObject == false)
                            {
                                gsm.Player.Inventory[obj].ItemStackCount += gsm.GameMap.CurrentLocation.LootableItems[item].ItemStackCount;
                                gsm.GameMap.CurrentLocation.LootableItems.RemoveAt(item);
                                break;
                            }
                            else if (gsm.Player.Inventory[obj].Name == gsm.GameMap.CurrentLocation.LootableItems[item].Name && gsm.GameMap.CurrentLocation.LootableItems[item].SpecialObject == true)
                            {
                                gsm.Player.Inventory.Add(gsm.GameMap.CurrentLocation.LootableItems[item]);
                                gsm.GameMap.CurrentLocation.LootableItems.RemoveAt(item);
                                break;
                            } 
                            else if(gsm.Player.Inventory[obj].Name != gsm.GameMap.CurrentLocation.LootableItems[item].Name)
                            {
                                gsm.Player.Inventory.Add(gsm.GameMap.CurrentLocation.LootableItems[item]);
                                gsm.GameMap.CurrentLocation.LootableItems.RemoveAt(item);
                                break;
                            }
                        }
                      
                    }
                     if (gsm.Player.Inventory.Count == 0)
                    {
                        gsm.Player.Inventory.Add(gsm.GameMap.CurrentLocation.LootableItems[item]);
                        gsm.GameMap.CurrentLocation.LootableItems.RemoveAt(item);
                    }
                   
                  //  gsm.Player.Inventory.Add(gsm.GameMap.CurrentLocation.LootableItems[item]); 
                    

                }
                
            }
        }
        private void LocationLootListSelectorSetter(int selected)
        {
            _LocationLootListItemSelected = selected;
            for (int item = 0; item < gsm.GameMap.CurrentLocation.LootableItems.Count; item++)
            {
                if (gsm.GameMap.CurrentLocation.LootableItems[item].LocationListPlacement == selected)
                {
                    gsm.GameMap.CurrentLocation.LootableItems[item].HasListSelection = true;
                }
                else if (gsm.GameMap.CurrentLocation.LootableItems[item].LocationListPlacement != selected)
                {
                    gsm.GameMap.CurrentLocation.LootableItems[item].HasListSelection = false;
                }
            }
        }
        private void PlayerInventorySelectorSetter(int selected)
        {
            _PlayerInventoryItemSelected = selected;
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            {
                if (gsm.Player.Inventory[item].PlayerInventoryListPlacement == selected)
                {
                    gsm.Player.Inventory[item].HasPlayerInventorySelection = true;
                }
                else if (gsm.Player.Inventory[item].PlayerInventoryListPlacement != selected)
                {
                    gsm.Player.Inventory[item].HasPlayerInventorySelection = false;
                }
            }
        }
        private void UpdateListPlacement()
        {
            for (int item = 0; item < gsm.GameMap.CurrentLocation.LootableItems.Count; item++)
            {
                gsm.GameMap.CurrentLocation.LootableItems[item].LocationListPlacement = item;
            }
        }
        private void UpdatePlayerInventoryListPlacement()
        {
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            {
                gsm.Player.Inventory[item].PlayerInventoryListPlacement = item;
            }
        }
        private void LocationLootList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            UpdateListPlacement();
           LocationLootListSelectorSetter(item.SelectedIndex);
        }

        private void PlayerInventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender; 
            UpdatePlayerInventoryListPlacement();
            PlayerInventorySelectorSetter(item.SelectedIndex);
        }

        private void PlayerInventoryList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            {
                if (gsm.Player.Inventory[item].HasPlayerInventorySelection == true)
                {
                    if (gsm.Player.Inventory[item].Consumable == true && gsm.Player.Inventory[item].ConsumableUsed == false)
                    {
                        gsm.Player.Inventory[item].ConsumableUsed = true;
                        switch (gsm.Player.Inventory[item].Name)
                        {
                            case "Basic Healing Potion":
                                gsm.Player.Inventory.RemoveAt(item);
                                BasicHealingPotion potion = new BasicHealingPotion(gsm, gsv);
                                potion.potionUsedWithCooldown(gsm);
                                break; 
                            default:
                                break;
                        }
                    }
                }
            }
        }
          
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DropItem.IsEnabled = true;
            DropAll.IsEnabled = true;
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DropItem.IsEnabled = false;
            DropAll.IsEnabled = false;
        }
         
        private void DropItem_Click(object sender, RoutedEventArgs e)
        {
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            { 
                if (gsm.Player.Inventory[item].HasPlayerInventorySelection == true)
                {
                    if (gsm.Player.Inventory[item].ItemStackCount > 1)
                    {
                        gsm.Player.Inventory[item].ItemStackCount -= 1;
                         bool found = false;
                        for (int items = 0; items < gsm.GameMap.CurrentLocation.LootableItems.Count; items++)
                        {
                            
                            if (gsm.GameMap.CurrentLocation.LootableItems[items].Name == gsm.Player.Inventory[item].Name)
                            {
                                gsm.GameMap.CurrentLocation.LootableItems[items].ItemStackCount += 1;
                                found = true;
                                break;
                            }
                            else if(gsm.GameMap.CurrentLocation.LootableItems[items].Name != gsm.Player.Inventory[item].Name)
                            {
                                found = false;
                            }
                        }
                        if (found == false)
                        {
                            gsm.GameMap.CurrentLocation.LootableItems.Add(gsm.Player.Inventory[item]);
                        }
                    } 
                    else if (gsm.Player.Inventory[item].ItemStackCount == 1)
                    {

                        bool found = false;
                        for (int items = 0; items < gsm.GameMap.CurrentLocation.LootableItems.Count; items++)
                        {

                            if (gsm.GameMap.CurrentLocation.LootableItems[items].Name == gsm.Player.Inventory[item].Name)
                            {
                                gsm.GameMap.CurrentLocation.LootableItems[items].ItemStackCount += 1;
                                found = true;
                                break;
                            }
                            else if (gsm.GameMap.CurrentLocation.LootableItems[items].Name != gsm.Player.Inventory[item].Name)
                            {
                                found = false;
                            }
                        }
                        if (found == false)
                        {
                            gsm.GameMap.CurrentLocation.LootableItems.Add(gsm.Player.Inventory[item]);
                        }
                        gsm.Player.Inventory.RemoveAt(item);

                    }
                } 
            }
        }

        private void DropAll_Click(object sender, RoutedEventArgs e)
        {
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            {
                if (gsm.Player.Inventory[item].HasPlayerInventorySelection == true)
                {
                    if (gsm.Player.Inventory[item].ItemStackCount > 1)
                    {
                         
                        bool found = false;
                        for (int items = 0; items < gsm.GameMap.CurrentLocation.LootableItems.Count; items++)
                        {

                            if (gsm.GameMap.CurrentLocation.LootableItems[items].Name == gsm.Player.Inventory[item].Name)
                            {
                                gsm.GameMap.CurrentLocation.LootableItems[items].ItemStackCount += gsm.Player.Inventory[item].ItemStackCount;
                                found = true;
                                gsm.Player.Inventory.RemoveAt(item);
                                break;
                            }
                            else if (gsm.GameMap.CurrentLocation.LootableItems[items].Name != gsm.Player.Inventory[item].Name)
                            {
                                found = false;
                            }
                        }
                        if (found == false)
                        {
                            gsm.GameMap.CurrentLocation.LootableItems.Add(gsm.Player.Inventory[item]);
                        }
                    }
                    else if (gsm.Player.Inventory[item].ItemStackCount == 1)
                    {

                        bool found = false;
                        for (int items = 0; items < gsm.GameMap.CurrentLocation.LootableItems.Count; items++)
                        {

                            if (gsm.GameMap.CurrentLocation.LootableItems[items].Name == gsm.Player.Inventory[item].Name)
                            {
                                gsm.GameMap.CurrentLocation.LootableItems[items].ItemStackCount += 1;
                                found = true;
                                break;
                            }
                            else if (gsm.GameMap.CurrentLocation.LootableItems[items].Name != gsm.Player.Inventory[item].Name)
                            {
                                found = false;
                            }
                        }
                        if (found == false)
                        {
                            gsm.GameMap.CurrentLocation.LootableItems.Add(gsm.Player.Inventory[item]);
                        }
                        gsm.Player.Inventory.RemoveAt(item);

                    }
                }
            }
        }
    }
}

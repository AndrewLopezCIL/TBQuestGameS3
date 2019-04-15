using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public abstract class Item
    {
        //
        // Current Trackable ID of the Item
        //
        private int _itemID;

        public int ID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        //
        // The item's display name
        //
        private string _itemName;

        public string Name
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        //
        // How much the item is worth in Gold
        //
        private int _itemValue;

        public int Value
        {
            get { return _itemValue; }
            set { _itemValue = value; }
        }
        //
        // To keep track of how much the player is currently carrying
        //
        private int _itemStackCount;

        public int ItemStackCount
        {   
            get { return _itemStackCount; }
            set { _itemStackCount = value; }
        }
        //
        // Whether or not the player can equip the item
        //
        private bool _equipable;

        public bool CanEquip
        {
            get { return _equipable; }
            set { _equipable = value; }
        }
        //
        // Whether or not the item can be consumed/used ( as in a buff type way not equipable )
        //
        private bool _consumable;

        public bool Consumable
        {
            get { return _consumable; }
            set { _consumable = value; }
        }

        //
        // If the item is in the player's inventory/was collected by the player
        //
        private bool _collected;
            
        public bool Collected
        {
            get { return _collected; }
            set { _collected = value; }
        }

        private bool _consumableUsed;

        public bool ConsumableUsed
        {
            get { return _consumableUsed; }
            set { _consumableUsed = value; }
        }

        #region METHODS
        public void collectItem(GameSessionViewModel gsm, Item itemObject)
        {
            bool contains = false; 
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            {
                if (gsm.Player.Inventory[item].Name == this.Name)
                {
                    contains = true;
                    itemObject = gsm.Player.Inventory[item];
                }
                else if (gsm.Player.Inventory[item].Name != this.Name)
                {
                    contains = false;
                } 
            }
            if (contains)
            {
                itemObject.ItemStackCount += 1;
                this.Collected = true;
            }
            else if (contains == false)
            {
                gsm.Player.Inventory.Add(this);
            }

        }
        #endregion

    }
}

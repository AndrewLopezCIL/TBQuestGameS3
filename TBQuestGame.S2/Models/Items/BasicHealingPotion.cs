using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Items
{
    public class BasicHealingPotion : Item
    {
        public GameSessionViewModel viewModel;
        private double _healingAMT;
        public DispatcherTimer healingTimer = new System.Windows.Threading.DispatcherTimer();
        public DispatcherTimer healingCooldown = new System.Windows.Threading.DispatcherTimer();
        public double HealingIncrement
        {
            get { return _healingAMT; }
            set { _healingAMT = value; }
        }
        private bool _beingUsed;

        public bool BeingUsed
        {
            get { return _beingUsed; }
            set { _beingUsed = value; }
        }
            
        public void potionUsedWithCooldown(GameSessionViewModel gsm)
        {
            if (BeingUsed == false)
            {
                healingCooldown.Tick += new EventHandler(potionUsed);
                healingCooldown.Interval = new TimeSpan(0,0,2);
                healingCooldown.Start();
            }

        }      
        public void potionUsed(object sender, EventArgs e)
        {
            healingCooldown.Stop();
            if (ConsumableUsed == false) {
                this.ConsumableUsed = true;
                this.BeingUsed = true;
                healingTimer.Tick += new EventHandler(HealPlayer);
                healingTimer.Interval = new TimeSpan(0, 0, 1);
                healingTimer.Start();
                //
                // Remove item from player's inventory if the item's stack count is 1
                // Otherwise, decrement the ItemStackCount if there is more than 1
                //
                for (int item = 0; item < viewModel.Player.Inventory.Count; item++)
                {
                    if(viewModel.Player.Inventory[item].ID == this.ID)
                    {
                        if (viewModel.Player.Inventory[item].ItemStackCount == 1)
                        {
                            viewModel.Player.Inventory.RemoveAt(item);
                            this.ItemStackCount -= 1;
                        }
                        else if (viewModel.Player.Inventory[item].ItemStackCount > 1)
                        {
                            viewModel.Player.Inventory[item].ItemStackCount -= 1;
                        }
                    }
                }
            } 
        }
        private void HealPlayer(object sender, EventArgs e)
        {
            viewModel.PlayerHealth += this.HealingIncrement;
        }
        public BasicHealingPotion(GameSessionViewModel gsm)
        {
            this.viewModel = gsm;
            this.HealingIncrement = 3.5;
            this.Name = "Basic Healing Potion";
            this.Consumable = true;
            this.CanEquip = false;
            this.Value = 35;
            this.ItemStackCount += 1;
            gsm._gameData.itemID += 1;
            this.ConsumableUsed = false;

        }
    }
}
    
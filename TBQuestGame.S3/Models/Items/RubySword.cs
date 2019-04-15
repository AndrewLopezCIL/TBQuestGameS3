using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Items
{
    public class RubySword : Item
    {
        private double _swordDamage;

        public double Damage
        {
            get { return _swordDamage; }
            set { _swordDamage = value; }
        }


        public RubySword(GameSessionViewModel gsm, GameSessionView gsv)
        {
            //Mid Level Sword : Moderate damage
            this._swordDamage = 6.3;
            this.Consumable = false;
            this.Collected = false;
            this.SpecialObject = false;
            this.PicturePath = "/Images/swendivericon.png";
            this.PictureSource = gsv.getPictureSource(this.PicturePath);
            if (gsm.Player.Level >= 3) {
                this.CanEquip = true;
            }else{
                this.CanEquip = false;
            }
            this.ID = gsm._gameData.itemID += 1;
            this.ItemStackCount += 1;
            this.Value = 225;
            this.Name = "Ruby Sword";
        }


    }
}

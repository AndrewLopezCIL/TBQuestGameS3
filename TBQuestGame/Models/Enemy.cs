using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class Enemy
    {

        #region FIELDS
        private double _health;
        private double _baseAttack = 2.9;
        private double _criticalAttack;
        private double _xpDrop;
        private double _itemDrop;
        private string _name;
        #endregion

        #region PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Health
        {
            get { return _health; }
            set { _health = value; }
        } 
        public double XPDrop
        {
            get { return _xpDrop; }
            set { _xpDrop= value; }
        }
        public double ItemDrop
        {
            get { return _itemDrop; }
            set { _itemDrop = value; }
        } 
        public double BaseAttack
        {
            get { return _baseAttack; }
            set { _baseAttack = value; }
        }
        #endregion

        #region METHODS
        public double getCriticalAttack()
        { 
            _criticalAttack = _baseAttack + (_baseAttack * .30);
            return _criticalAttack;
        }
        #endregion

        #region CONSTRUCTORS

        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        public enum AttackType {
            BasicAttack, SkillOneAttack, SkillTwoAttack, SkillThreeAttack, ThirdEyeAttack
        }

        #region FIELDS
        private double _shield;
        private double _basicAttack = 3.2;
        private double _skillOneAttack;
        private double _skillTwoAttack;
        private double _skillThreeAttack;
        private double _thirdEyeAttack;
        private int _gold;
        // May remove quest points in the future
        private int _questPoints;
        #endregion

        #region PROPERTIES
        public int QuestPoints
        {
            get { return _questPoints; }
            set { _questPoints = value; }
        }
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public double Shield
        {
            get{ return _shield; }
            set { _shield = value; }
        }
        public double BasicAttack
        {
            get { return _basicAttack; }
            set { _basicAttack = value; }
        }
        public double SkillOneAttack
        {
            get { return _skillOneAttack; }
            set { _skillOneAttack = value; }
        }
        public double SkillTwoAttack
        {
            get { return _skillTwoAttack; }
            set { _skillTwoAttack = value; }
        }
        public double SkillThreeAttack
        {
            get { return _skillThreeAttack; }
            set { _skillThreeAttack = value; }
        }
        public double ThirdEyeAttack
        {
            get { return _thirdEyeAttack; }
            set { _thirdEyeAttack = value; }
        }
        #endregion

        #region METHODS 
        public override string GetName()
            {
                return base.GetName();
            }
        
            public override bool Alive()
            {
                return IsAlive ? true : false;
            }
        #endregion

        #region CONSTRUCTORS

        #endregion

        
    }
}

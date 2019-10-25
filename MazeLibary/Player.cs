using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;

namespace MazeLibrary
{
    public class Player : BaseCell
    {
        /// <summary>
        /// create player by template Singleton
        /// </summary>
        #region Singleton
            
        private static Player _player;  //приватное статическое поле
      
        public static Player GetPlayer  //паблик свойство
        {
            get
            {
                return _player ?? (_player = new Player());
            }
        }

        private Player() : base(0,0, '@') { }  //приватный конструктор

        #endregion


        public override bool TryToStep()
        {
            throw new Exception("Its not allowed");
        }


       
    }
}

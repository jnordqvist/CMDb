﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipGame.ViewModels
{
    public class MainViewModel : BaseViewModel 
    {
        public BaseViewModel CurrentViewModel { get; set; } = new GameViewModel();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions.Pages
{
    public  interface ILoginPageHelper
    {

        void EnterUserNamePasswordAndClickLogin(string userName, string password);
    }
}

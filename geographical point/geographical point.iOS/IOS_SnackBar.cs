using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using geographical_point.Models;
using TTGSnackBar;
using UIKit;

namespace geographical_point.iOS
{
    class IOS_SnackBar:SnackBar
    {
        public void ShowSnackBar(string Message)
        {
            var snackbar = new TTGSnackbar(Message);
            snackbar.Duration = TimeSpan.FromSeconds(2);
            snackbar.Show();
        }
    }
}
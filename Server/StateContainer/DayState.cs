using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.Models;

namespace Server.StateContainer
{
    public class DayState
    {
        public event Action OnChange;

        public void UpdateToDos()
        {
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
using ESChatWindows.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Data
{
    public class ApplicationBindingDataContext
    {
        protected ApplicationDataContext DataContext { get; set; } = ApplicationDataContext.GetInstance();

        protected ApplicationBindingDataContext()
        {

        }
        protected static ApplicationBindingDataContext _Instance;

        public static ApplicationBindingDataContext GetInstance()
        {
            if (ApplicationBindingDataContext._Instance == null)
                ApplicationBindingDataContext._Instance = new ApplicationBindingDataContext();
            return ApplicationBindingDataContext._Instance;
        }

        public TokenModel Token => this.DataContext.Token;
    }
}

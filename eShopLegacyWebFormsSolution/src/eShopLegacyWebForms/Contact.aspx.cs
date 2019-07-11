using log4net;
using System;
using System.Web.UI;

namespace eShopLegacyWebForms
{
    public partial class Contact : Page
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            _log.Info("Now loading... /Contact.aspx");
        }
    }
}
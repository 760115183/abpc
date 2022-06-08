using Abp.Application.Navigation;
using Abp.Localization;

namespace Lis.PiYanSuoReport.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class PiYanSuoReportNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", PiYanSuoReportConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", PiYanSuoReportConsts.LocalizationSourceName),
                        url: "About",
                        icon: "fa fa-info"
                        )
                );
        }
    }
}

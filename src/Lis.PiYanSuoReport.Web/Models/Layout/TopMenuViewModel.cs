﻿using Abp.Application.Navigation;

namespace Lis.PiYanSuoReport.Web.Models.Layout
{
    public class TopMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}
﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ZenithAssignment.ViewModels.Authorization
{
    public class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}

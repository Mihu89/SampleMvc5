﻿namespace SampleMvc5.ViewModels
{
    public class VerifyCodeViewModel
    {
        public string Provider { get; set; }
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
﻿#region Usings
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystemWeb.Api
{
    public abstract class BaseController : Controller
    {
        public string Cpf => User.Claims.GetValue("Cpf");
        public int CdPessoa => Convert.ToInt32(User.Claims.GetValue("CdPessoa"));
        public bool Admin => User.Claims.GetValue("Admin") == "S";
        public int SqContratoTrabalho => Convert.ToInt32(User.Claims.GetValue("SqContratoTrabalho"));
        public bool Pensionista => Convert.ToBoolean(User.Claims.GetValue("Pensionista"));
    }
}
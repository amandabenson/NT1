﻿using System.Web;
using System.Web.Mvc;

namespace NT1
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new Filters.VerificaSesion());
		}
	}
}

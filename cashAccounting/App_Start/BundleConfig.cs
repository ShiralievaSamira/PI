﻿using System.Web;
using System.Web.Optimization;

namespace cashAccounting
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                      //  "~/Scripts/moment.js"  //added for bootstrap date time picker
                        ));

            //bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include( //
            //              "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery.datetimepicker").Include(  //
            //            "~/Scripts/jquery.datetimepicker.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      //   "~/Scripts/bootstrap-datetimepicker.js" //added for bootstrap date time picker
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.datetimepicker.css"   //
                      //    "~/Content/bootstrap-datetimepicker.css" //added for bootstrap date time picker
                      ));
        }
    }
}

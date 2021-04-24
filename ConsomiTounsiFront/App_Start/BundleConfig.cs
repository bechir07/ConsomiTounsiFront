using System.Web;
using System.Web.Optimization;

namespace ConsomiTounsiFront
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region Template Desing

            bundles.Add(new ScriptBundle("~/template/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.smartmenus.js",
                      "~/Scripts/jquery.smartmenus.bootstrap.js",
                      "~/Scripts/sequence.js",
                      "~/Scripts/sequence-theme.modern-slide-in.js",
                      "~/Scripts/jquery.simpleGallery.js",
                      "~/Scripts/jquery.simpleLens.js",
                      "~/Scripts/slick.js",
                      "~/Scripts/nouislider.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/templateAdmin/css").Include(
                      "~/Content/Admin/font-awesome.css",
                      "~/Content/Admin/bootstrap.css",
                      "~/Content/Admin/custom-styles.css",
                      "~/Scripts/Admin/morris/morris-0.4.3.min.css",
                      "~/Content/Admin/custom-styles.css",
                      "~/Content/Admin/nouislider.css",
                      "~/Content/Admin/theme-color/default-theme.css",
                      "~/Content/Admin/sequence-theme.modern-slide-in.css",
                      "~/Content/Admin/style.css"));

            bundles.Add(new ScriptBundle("~/templateAdmin/js").Include(
                      "~/Scripts/Admin/jquery-1.10.2.js",
                      "~/Scripts/Admin/bootstrap.min.js",
                      "~/Scripts/Admin/jquery.metisMenu.js",
                      "~/Scripts/Admin/morris/raphael-2.1.0.min.js",
                      "~/Scripts/Admin/morris/morris.js",
                      "~/Scripts/Admin/easypiechart.js",
                      "~/Scripts/Admin/easypiechart-data.js",
                      "~/Scripts/Admin/Lightweight-Chart/jquery.chart.js",
                      "~/Scripts/Admin/custom-scripts.js",
                      "~/Scripts/Admin/Chart.min.js",
                      "~/Scripts/Admin/chartjs.js"));

            #endregion
        }
    }
}

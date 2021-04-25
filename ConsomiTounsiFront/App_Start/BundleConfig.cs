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

            bundles.Add(new StyleBundle("~/template/css").Include(
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/jquery.smartmenus.bootstrap.css",
                      "~/Content/css/jquery.simpleLens.css",
                      "~/Content/css/slick.css",
                      "~/Content/css/nouislider.css",
                      "~/Content/css/theme-color/default-theme.css",
                      "~/Content/css/sequence-theme.modern-slide-in.css",
                      "~/Content/css/style.css"));

            #endregion
        }
    }
}

using System;
using System.Web.Mvc;

namespace Alanta.Mvc.Sample
{
   /// <summary>
   /// A simple controller demonstrating page composition using Alanta.Mvc.
   /// </summary>
   public class Home : Controller
   {
      /// <summary>
      /// Index action.
      /// </summary>
      public ActionResult Index()
      {
         // Setup the result to use Default.master as the master page.
         var result = new TemplateResult() { MasterPageFile = "~/Default.master" };
         // Setup some viewdata
         ViewData[ "title" ] = "Home"; // Master page needs title
         ViewData[ "MVC" ] = "Cool";

         // Load a plain ASP.NET user control into the Body template
         result.AddControl( "Body", "~/Controls/HelloWorld.ascx" );

         // Load a custom control instance into the Body template
         result.AddControl( "Body",
            new Block()
            {
               CssClass = "block",
               Text = String.Format( "Page processed at {0}", DateTime.Now )
            }
         );

         // Load an MVC view user control into the Right template
         result.AddControl( "Right", "~/Views/ViewDataDumper.ascx" );

         return result;
      }
   }
}
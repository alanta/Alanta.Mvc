// Copyright (c) 2008-2009, Alanta, Tilburg, The Netherlands
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//    * Redistributions of source code must retain the above copyright
//      notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright
//      notice, this list of conditions and the following disclaimer in the
//      documentation and/or other materials provided with the distribution.
//    * Neither the name of the <organization> nor the
//      names of its contributors may be used to endorse or promote products
//      derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY ALANTA ''AS IS'' AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL ALANTA BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// For more information and updates please visit http://blog.alanta.nl/
//

using System.Web.Mvc;
using System.Web.UI;

namespace Alanta.Mvc
{
   /// <summary>
   /// Extensions for controller.
   /// </summary>
   public static class ControllerExtensions
   {
      /// <summary>
      /// Renders the view with the specified virtual path.
      /// </summary>
      /// <param name="controller">The controller.</param>
      /// <param name="masterPage">The master page.</param>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="virtualPath">The virtual path.</param>
      /// <returns></returns>
      public static ActionResult TemplateView( this Controller controller, string masterPage, string templateName, string virtualPath )
      {
         TemplateResult result = new TemplateResult();
         result.MasterPageFile = masterPage;
         result.AddControl( templateName, virtualPath );
         return result;
      }

      /// <summary>
      /// Renders the view with the specified virtual path.
      /// </summary>
      /// <param name="controller">The controller.</param>
      /// <param name="masterPage">The master page.</param>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="virtualPath">The virtual path.</param>
      /// <param name="model">The model.</param>
      /// <returns></returns>
      public static ActionResult TemplateView( this Controller controller, string masterPage, string templateName, string virtualPath, object model )
      {
         controller.ViewData.Model = model;
         return controller.TemplateView( masterPage, templateName, virtualPath );
      }

      /// <summary>
      /// Renders the view using the specified control.
      /// </summary>
      /// <param name="controller">The controller.</param>
      /// <param name="masterPage">The master page.</param>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="control">The control.</param>
      /// <returns></returns>
      public static ActionResult TemplateView( this Controller controller, string masterPage, string templateName, Control control )
      {
         TemplateResult result = new TemplateResult();
         result.MasterPageFile = masterPage;
         result.AddControl( templateName, control );
         return result;
      }

      /// <summary>
      /// Renders the view using the specified control.
      /// </summary>
      /// <param name="controller">The controller.</param>
      /// <param name="masterPage">The master page.</param>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="control">The control.</param>
      /// <param name="model">The model.</param>
      /// <returns></returns>
      public static ActionResult TemplateView( this Controller controller, string masterPage, string templateName, Control control, object model )
      {
         controller.ViewData.Model = model;
         return controller.TemplateView( masterPage, templateName, control );
      }
   }
}

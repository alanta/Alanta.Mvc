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

using System;
using System.Web.Mvc;
using System.Web.UI;

namespace Alanta.Mvc
{
   /// <summary>
   /// ActionResult that renders a view using controls and no .aspx file.
   /// </summary>
   public class TemplateResult : ActionResult, IView
   {
      /// <summary>
      /// Gets the page instance used to render the view.
      /// </summary>
      /// <value>The page instance used to render the view.</value>
      public ViewPage Page
      {
         get { return _page; }
      }

      /// <summary>
      /// Gets or sets the theme.
      /// </summary>
      /// <value>The theme.</value>
      public string Theme
      {
         get { return _page.Theme; }
         set { _page.Theme = value; }
      }

      /// <summary>
      /// Gets or sets the master page file.
      /// </summary>
      /// <value>The master page file.</value>
      public string MasterPageFile
      {
         get { return _page.MasterPageFile; }
         set
         {
            if ( string.IsNullOrEmpty( value ) )
               throw new ArgumentNullException( "value", "MasterPageFile must not be null or empty." );
            _page.MasterPageFile = value;
         }
      }

      /// <summary>
      /// Adds the control.
      /// </summary>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="virtualPath">The virtual path.</param>
      public void AddControl( string templateName, string virtualPath )
      {
         if ( string.IsNullOrEmpty( templateName ) )
            throw new ArgumentNullException( "templateName", "Template name must not be null or empty." );

         if ( string.IsNullOrEmpty( virtualPath ) )
            throw new ArgumentNullException( "virtualPath", "The virtual path must not be null or empty." );

         Template template;
         if ( !_page.Templates.TryGetValue( templateName, out template ) )
         {
            template = new Template();
            _page.Templates.Add( templateName, template );
         }
         template.AddControl( virtualPath );
      }

      /// <summary>
      /// Adds the control.
      /// </summary>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="controlInstance">The control instance.</param>
      public void AddControl( string templateName, Control controlInstance )
      {
         if ( string.IsNullOrEmpty( templateName ) )
            throw new ArgumentNullException( "templateName", "Template name must not be null or empty." );

         if ( null == controlInstance )
            throw new ArgumentNullException( "controlInstance", "The control instance must not be null." );

         Template template;
         if ( !_page.Templates.TryGetValue( templateName, out template ) )
         {
            template = new Template();
            _page.Templates.Add( templateName, template );
         }
         template.AddControl( controlInstance );
      }

      /// <summary>
      /// Executes the result.
      /// </summary>
      /// <param name="context">The context.</param>
      public override void ExecuteResult( ControllerContext context )
      {
         if ( string.IsNullOrEmpty( MasterPageFile ) )
            throw new InvalidOperationException( "MasterPageFile must not be null or empty." );

         var viewContext = new ViewContext( context, this, context.Controller.ViewData, context.Controller.TempData );
         Render( viewContext, context.HttpContext.Response.Output );
      }

      /// <summary>
      /// Renders the view.
      /// </summary>
      /// <param name="viewContext">The view context.</param>
      /// <param name="writer">Not used.</param>
      public void Render( ViewContext viewContext, System.IO.TextWriter writer )
      {
         _page.ViewData = viewContext.ViewData;
         _page.AppRelativeTemplateSourceDirectory = "~/";
         _page.AppRelativeVirtualPath = "~/";
         _page.RenderView( viewContext );
      }

      TemplateViewPage _page = new TemplateViewPage();
   }
}

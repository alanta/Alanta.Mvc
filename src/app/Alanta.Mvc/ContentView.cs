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

namespace Alanta.Mvc
{
   /// <summary>
   /// Returns a single view that loads a control into a master page.
   /// </summary>
   public class ContentView : Controller
   {
      /// <summary>
      /// Gets or sets the virtual path to the control to render.
      /// </summary>
      /// <value>The virtual path.</value>
      public string VirtualPath { get; set; }

      /// <summary>
      /// Executes the specified request context.
      /// </summary>
      /// <returns></returns>
      public ActionResult Default( )
      {
         string virtualPath = ControllerContext.RouteData.GetRequiredString( "VirtualPath" );
         string templateName = ControllerContext.RouteData.GetRequiredString( "TemplateName" );
         string masterPage = ControllerContext.RouteData.GetRequiredString( "MasterPageFile" );
         object theme;
         ControllerContext.RouteData.DataTokens.TryGetValue( "Theme", out theme );
         TemplateResult result = new TemplateResult();
         result.MasterPageFile = masterPage;
         result.Theme = ( theme == null ) ? string.Empty : ( string )theme;
         result.AddControl( templateName, virtualPath );
         return result;
      }
   }
}

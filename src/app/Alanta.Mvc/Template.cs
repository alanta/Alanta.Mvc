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
using System.Collections.Generic;
using System.Web.UI;

namespace Alanta.Mvc
{
   /// <summary>
   /// A template.
   /// </summary>
   internal class Template : ITemplate
   {
      /// <summary>
      /// Adds the control.
      /// </summary>
      /// <param name="virtualPath">The virtual path.</param>
      public void AddControl( string virtualPath )
      {
         if ( string.IsNullOrEmpty( virtualPath ) )
            throw new ArgumentNullException( "virtualPath" );

         if ( virtualPath[ 0 ] != '~' && virtualPath[ 0 ] != '/' )
         {
            _items.Add( new TemplateItem { _virtualPath = string.Format( "~/{0}", virtualPath ) } );
         }
         else
         {
            _items.Add( new TemplateItem { _virtualPath = virtualPath } );
         }
      }

      /// <summary>
      /// Adds the control.
      /// </summary>
      /// <param name="controlInstance">The control instance.</param>
      public void AddControl( Control controlInstance )
      {
         if ( null == controlInstance )
            throw new ArgumentNullException( "controlInstance" );

         _items.Add( new TemplateItem { _control = controlInstance } );
      }

      /// <summary>
      /// Defines the <see cref="T:System.Web.UI.Control"/> object that child 
      /// controls and templates belong to. These child controls are in turn defined within an inline template.
      /// </summary>
      /// <param name="container">The <see cref="T:System.Web.UI.Control"/> object to contain 
      /// the instances of controls from the inline template.</param>
      void ITemplate.InstantiateIn( Control container )
      {
         foreach ( var item in _items )
         {
            var control = item._control;
            if ( null == control )
            {
               control = System.Web.Compilation.BuildManager.CreateInstanceFromVirtualPath( item._virtualPath, typeof( Control ) ) as Control;
            }

            container.Controls.Add( control );
         }
      }

      List<TemplateItem> _items = new List<TemplateItem>();
      

      private class TemplateItem
      {
         internal Control _control;
         internal string _virtualPath;   
      }
   }
}

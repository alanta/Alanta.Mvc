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
using System.Web.Routing;
using System.Web.Mvc;

namespace Alanta.Mvc
{
   /// <summary>
   /// Extensions for mapping routes in the admin site.
   /// </summary>
   public static class RouteExtensions
   {
      /// <summary>
      /// Maps a strong typed route.
      /// </summary>
      /// <typeparam name="T">The controller type.</typeparam>
      /// <param name="routes">The route collection to add to.</param>
      /// <param name="name">The name of the route.</param>
      /// <param name="url">The URL for the route.</param>
      /// <param name="defaults">The default values for this route.</param>
      /// <param name="constraints">The constraints for this route.</param>
      /// <returns>A strong typed route.</returns>
      /// <exception cref="ArgumentNullException">Occures when <paramref name="url"/> is <c>null</c>.</exception>
      public static Route MapRoute<T>( this RouteCollection routes, string name, string url, object defaults, object constraints )
         where T : Controller, new()
      {
         if ( routes == null )
         {
            throw new ArgumentNullException( "routes" );
         }
         if ( url == null )
         {
            throw new ArgumentNullException( "url" );
         }

         Route route = new Route( url, new MvcRouteHandler<T>() )
         {
            Defaults = new RouteValueDictionary( defaults ),
            Constraints = new RouteValueDictionary( constraints )
         };

         // For compatibility with MvcHandler
         route.Defaults.Add( "controller", typeof( T ).Name.Replace( "Controller", "" ) );

         routes.Add( name, route );
         return route;
      }
   }
}

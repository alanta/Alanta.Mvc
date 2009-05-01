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
using System.Web;

namespace Alanta.Mvc
{
   /// <summary>
   /// Handler for admin routes.
   /// </summary>
   /// <typeparam name="TController">The type of the controller.</typeparam>
   internal class MvcRouteHandler<TController> : System.Web.Routing.IRouteHandler
         where TController : System.Web.Mvc.Controller
   {
      /// <summary>
      /// Gets the HTTP handler to process the request.
      /// </summary>
      /// <param name="requestContext">The request context.</param>
      /// <returns>The HTTP handler to process the request.</returns>
      public IHttpHandler GetHttpHandler( System.Web.Routing.RequestContext requestContext )
      {
         return new MvcHttpHandler( Activator.CreateInstance<TController>(), requestContext );
      }
   }
}

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

using System.Web;

namespace Alanta.Mvc
{
   /// <summary>
   /// Http handler for strong typed routes.
   /// </summary>
   internal class MvcHttpHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MvcHttpHandler"/> class.
      /// </summary>
      /// <param name="controller">The controller.</param>
      /// <param name="context">The context.</param>
      public MvcHttpHandler( System.Web.Mvc.IController controller, System.Web.Routing.RequestContext context )
      {
         _controller = controller;
         _context = context;
      }
      /// <summary>
      /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
      /// </summary>
      /// <value></value>
      /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
      /// </returns>
      public bool IsReusable
      {
         get { return false; }
      }

      /// <summary>
      /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
      /// </summary>
      /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
      public void ProcessRequest( HttpContext context )
      {
         _controller.Execute( _context );
      }

      System.Web.Mvc.IController _controller;
      System.Web.Routing.RequestContext _context;
   } 
}

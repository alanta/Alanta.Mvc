using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

/// <summary>
/// A very simple control that renders a block of text using a div.
/// </summary>
public class Block : WebControl
{
   /// <summary>
   /// Initializes a new instance of the <see cref="Block"/> class.
   /// </summary>
   public Block() : base( "div" )
   {
      
   }

   /// <summary>
   /// Gets or sets the text.
   /// </summary>
   /// <value>The text.</value>
   public string Text { get; set; }

   /// <summary>
   /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
   /// </summary>
   /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
   protected override void RenderContents( System.Web.UI.HtmlTextWriter writer )
   {
      base.RenderContents( writer );
      writer.Write( Text );
   }
}

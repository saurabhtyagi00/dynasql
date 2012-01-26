﻿/*  Copyright 2012 PerceiveIT Limited
 *  This file is part of the Scryber library.
 *
 *  You can redistribute Scryber and/or modify 
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 * 
 *  Scryber is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 * 
 *  You should have received a copy of the GNU General Public License
 *  along with Scryber source code in the COPYING.txt file.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using Scryber.Styles;
using Scryber.Drawing;

namespace Scryber.Components.Support
{
    internal class CanvasLayoutEngine : ContainerLayoutEngine
    {

        public CanvasLayoutEngine(PDFContainerComponent owner, IPDFLayoutEngine parent, PDFLayoutContext context)
            : base(owner, parent, context)
        {
        }

        protected override void LayoutChildComponent(PDFComponent comp, out bool cont)
        {
            base.LayoutChildComponent(comp, out cont);
        }

        protected override void BeginComponentLayout(PDFComponent comp)
        {
            this.CurrentSpace = new PDFRect(PDFPoint.Empty, this.RootSpace.Size);
            base.BeginComponentLayout(comp);
        }

        PDFUnit rollingh = PDFUnit.Zero;

        protected override void EndComponentLayout(PDFComponent comp)
        {
            this.rollingh = PDFUnit.Max(rollingh, this.RequiredSpace.Height);
            this.MaxHeight = rollingh;
            base.EndComponentLayout(comp);
        }
    }
}
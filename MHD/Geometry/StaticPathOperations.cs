#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DirectInput;
using SharpDX.DirectWrite;

#endregion

namespace MHD.Geometry.Static
{

    public class Operations
    {

        public static PathGeometry PointsToPath(Point[] bounds)
        {
            PathGeometry Bounds = new PathGeometry(Content.ResourceManagers.Static.Operations.factory2D);
            using (GeometrySink gSink = Bounds.Open())
            {
                gSink.BeginFigure(bounds[0], FigureBegin.Filled);
                for (int i = 1; i < bounds.Length; i++) gSink.AddLine(bounds[i]);
                gSink.EndFigure(FigureEnd.Closed);
                gSink.Close();
            }
            return Bounds;
        }

        public static PathGeometry RectangleToPath(Rectangle bounds)
        {
            PathGeometry Bounds = new PathGeometry(Content.ResourceManagers.Static.Operations.factory2D);
            using (GeometrySink gSink = Bounds.Open())
            {
                gSink.BeginFigure(bounds.TopLeft, FigureBegin.Filled);
                gSink.AddLine(bounds.TopRight);
                gSink.AddLine(bounds.BottomRight);
                gSink.AddLine(bounds.BottomLeft);
                gSink.EndFigure(FigureEnd.Closed);
                gSink.Close();
            }
            return Bounds;
        }
        public static PathGeometry RectangleToPath(ref Rectangle bounds, out Vector2 translation)
        {
            translation = new Vector2(bounds.X, bounds.Y);
            bounds.X -= bounds.X + (bounds.Width / 2);
            bounds.Y -= bounds.Y + (bounds.Height / 2);
            return RectangleToPath(bounds);
        }

        public static PathGeometry EllipseToPath(Ellipse bounds)
        {
            PathGeometry Bounds = new PathGeometry(Content.ResourceManagers.Static.Operations.factory2D);
            using (GeometrySink gSink = Bounds.Open())
            {
                gSink.BeginFigure(new Vector2(-bounds.RadiusX, 0), FigureBegin.Filled);
                gSink.AddArc(new ArcSegment()
                {
                    ArcSize = ArcSize.Small,
                    Point = new Vector2(bounds.RadiusX, 0),
                    RotationAngle = 0,
                    Size = new Size2F(bounds.RadiusX, bounds.RadiusY),
                    SweepDirection = SweepDirection.Clockwise
                });
                gSink.AddArc(new ArcSegment()
                {
                    ArcSize = ArcSize.Small,
                    Point = new Vector2(-bounds.RadiusX, 0),
                    RotationAngle = 0,
                    Size = new Size2F(bounds.RadiusX, bounds.RadiusY),
                    SweepDirection = SweepDirection.Clockwise
                });
                gSink.EndFigure(FigureEnd.Closed);
                gSink.Close();
            }
            return Bounds;
        }
        public static PathGeometry EllipseToPath(ref Ellipse bounds, out Vector2 translation)
        {
            translation = bounds.Point;
            bounds.Point -= bounds.Point;
            return EllipseToPath(bounds);
        }

    }

}

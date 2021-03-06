using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp.ColorSpaces;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Xunit;

namespace SixLabors.ImageSharp.Drawing.Tests.Issues
{
    public class Issue_28
    {
        private Rgba32 red = Color.Red.ToRgba32();

        [Fact]
        public void DrawingLineAtTopShouldDisplay()
        {
            using var image = new Image<Rgba32>(Configuration.Default, 100, 100, Color.Black);
            image.Mutate(x => x
                    .SetGraphicsOptions(g => g.Antialias = false)
                    .DrawLines(
                        this.red,
                        1f,
                        new PointF(0, 0),
                        new PointF(100, 0)
                    ));

            var locations = Enumerable.Range(0, 100).Select(i => (x: i, y: 0));
            Assert.All(locations, l =>
            {
                Assert.Equal(this.red, image[l.x, l.y]);
            });
        }

        [Fact]
        public void DrawingLineAtBottomShouldDisplay()
        {
            using var image = new Image<Rgba32>(Configuration.Default, 100, 100, Color.Black);
            image.Mutate(x => x
                    .SetGraphicsOptions(g => g.Antialias = false)
                    .DrawLines(
                        this.red,
                        1f,
                        new PointF(0, 99),
                        new PointF(100, 99)
                    ));

            var locations = Enumerable.Range(0, 100).Select(i => (x: i, y: 99));
            Assert.All(locations, l =>
            {
                Assert.Equal(this.red, image[l.x, l.y]);
            });
        }

        [Fact]
        public void DrawingLineAtLeftShouldDisplay()
        {
            using var image = new Image<Rgba32>(Configuration.Default, 100, 100, Color.Black);
            image.Mutate(x => x
                    .SetGraphicsOptions(g => g.Antialias = false)
                    .DrawLines(
                        this.red,
                        1f,
                        new PointF(0, 0),
                        new PointF(0, 99)
                    ));

            var locations = Enumerable.Range(0, 100).Select(i => (x: 0, y: i));
            Assert.All(locations, l =>
            {
                Assert.Equal(this.red, image[l.x, l.y]);
            });
        }

        [Fact]
        public void DrawingLineAtRightShouldDisplay()
        {
            using var image = new Image<Rgba32>(Configuration.Default, 100, 100, Color.Black);
            image.Mutate(x => x
                    .SetGraphicsOptions(g => g.Antialias = false)
                    .DrawLines(
                        this.red,
                        1f,
                        new PointF(99, 0),
                        new PointF(99, 99)
                    ));

            var locations = Enumerable.Range(0, 100).Select(i => (x: 99, y: i));
            Assert.All(locations, l =>
            {
                Assert.Equal(this.red, image[l.x, l.y]);
            });
        }
    }
}

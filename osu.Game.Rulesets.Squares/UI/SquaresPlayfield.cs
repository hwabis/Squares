// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.UI;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Squares.UI
{
    [Cached]
    public class SquaresPlayfield : Playfield
    {
        private Container parentContainer;
        private GridContainer grid;
        private Square[] squares = new Square[9];

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                parentContainer = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(480), // you know what this is good enough for now ok
                    Children = new Drawable[]
                    {
                        grid = new GridContainer { RelativeSizeAxes = Axes.Both },
                        HitObjectContainer,
                        /*new Container
                        {
                            RelativeSizeAxes = Axes.Both,
                            Masking = true,
                            BorderColour = Color4.Red,
                            BorderThickness = 5,
                            Child = new Box
                            {
                                RelativeSizeAxes = Axes.Both,
                                Alpha = 0.5f,
                                AlwaysPresent = true
                            }
                        }*/
                    }
                }
            });

            Drawable[][] tmp = new Drawable[3][];
            for (int i = 0; i < 3; i++)
            {
                tmp[i] = new Drawable[]
                {
                    squares[3*i+0] = new Square() { RelativeSizeAxes = Axes.Both },
                    squares[3*i+1] = new Square() { RelativeSizeAxes = Axes.Both },
                    squares[3*i+2] = new Square() { RelativeSizeAxes = Axes.Both },
                };
            }
            grid.Content = tmp;
        }
        private class Square : CompositeDrawable
        {
            public Square()
            {
                InternalChildren = new Drawable[]
                {
                    new Box
                    {
                        Colour = Color4.Purple,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Height = 0.95f,
                        Width = 0.95f
                    },
                };

                Masking = true;
                CornerRadius = 20;
            }
        }
    }
}

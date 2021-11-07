// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Squares.Beatmaps;
using osu.Game.Rulesets.Squares.Mods;
using osu.Game.Rulesets.Squares.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;
using osuTK;
using osuTK.Graphics;
using static osu.Game.Rulesets.Squares.UI.SquaresPlayfield;

namespace osu.Game.Rulesets.Squares
{
    public class SquaresRuleset : Ruleset
    {
        public override string Description => "a very squaresruleset ruleset";

        public override DrawableRuleset CreateDrawableRulesetWith(IBeatmap beatmap, IReadOnlyList<Mod> mods = null) =>
            new DrawableSquaresRuleset(this, beatmap, mods);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) =>
            new SquaresBeatmapConverter(beatmap, this);

        public override DifficultyCalculator CreateDifficultyCalculator(WorkingBeatmap beatmap) =>
            new SquaresDifficultyCalculator(this, beatmap);

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Automation:
                    return new[] { new SquaresModAutoplay() };

                default:
                    return new Mod[] { null };
            }
        }

        public override string ShortName => "squaresruleset";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Q, SquaresAction.Button1),
            new KeyBinding(InputKey.W, SquaresAction.Button2),
            new KeyBinding(InputKey.E, SquaresAction.Button3),
            new KeyBinding(InputKey.A, SquaresAction.Button4),
            new KeyBinding(InputKey.S, SquaresAction.Button5),
            new KeyBinding(InputKey.D, SquaresAction.Button6),
            new KeyBinding(InputKey.Z, SquaresAction.Button7),
            new KeyBinding(InputKey.X, SquaresAction.Button8),
            new KeyBinding(InputKey.C, SquaresAction.Button9),
        };

        public override Drawable CreateIcon() => new Icon();

        // pretty sure this is the wrong way to do it but it's low priority
        public class Icon : CompositeDrawable
        {
            private GridContainer grid;

            public Icon()
            {
                InternalChildren = new Drawable[]
                {
                    new Container
                    {
                        Origin = Anchor.TopLeft,
                        Size = new Vector2(24),
                        Children = new Drawable[]
                        {
                            grid = new GridContainer { RelativeSizeAxes = Axes.Both }
                        }
                    }
                };

                Drawable[][] tmp = new Drawable[3][];
                for (int i = 0; i < 3; i++)
                {
                    tmp[i] = new Drawable[]
                    {
                        new Square() { RelativeSizeAxes = Axes.Both },
                        new Square() { RelativeSizeAxes = Axes.Both },
                        new Square() { RelativeSizeAxes = Axes.Both },
                    };
                }
                grid.Content = tmp;
            }

            // um i copy pasted this from playfield..
            private class Square : CompositeDrawable
            {
                public Square()
                {
                    InternalChildren = new Drawable[]
                    {
                        new Box
                        {
                            Colour = Color4.White,
                            RelativeSizeAxes = Axes.Both,

                            Height = 0.8f,
                            Width = 0.8f
                        },
                    };

                    Masking = true;
                    CornerRadius = 2;
                }
            }
        }
    }
}

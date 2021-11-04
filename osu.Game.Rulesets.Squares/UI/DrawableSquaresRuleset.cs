// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Squares.Objects;
using osu.Game.Rulesets.Squares.Objects.Drawables;
using osu.Game.Rulesets.Squares.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Squares.UI
{
    [Cached]
    public class DrawableSquaresRuleset : DrawableRuleset<SquaresHitObject>
    {
        public DrawableSquaresRuleset(SquaresRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
        }

        protected override Playfield CreatePlayfield() => new SquaresPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new SquaresFramedReplayInputHandler(replay);

        public override DrawableHitObject<SquaresHitObject> CreateDrawableRepresentation(SquaresHitObject h) => new DrawableSquaresHitObject(h);

        protected override PassThroughInputManager CreateInputManager() => new SquaresInputManager(Ruleset?.RulesetInfo);
    }
}

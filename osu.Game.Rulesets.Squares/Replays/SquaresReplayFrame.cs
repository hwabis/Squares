// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Rulesets.Replays;
using osuTK;

namespace osu.Game.Rulesets.Squares.Replays
{
    public class SquaresReplayFrame : ReplayFrame
    {
        public List<SquaresAction> Actions = new List<SquaresAction>();
        public Vector2 Position;

        public SquaresReplayFrame(SquaresAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }
    }
}

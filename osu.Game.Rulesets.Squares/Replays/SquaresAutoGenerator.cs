// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Squares.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Squares.Replays
{
    public class SquaresAutoGenerator : AutoGenerator<SquaresReplayFrame>
    {
        public new Beatmap<SquaresHitObject> Beatmap => (Beatmap<SquaresHitObject>)base.Beatmap;

        public SquaresAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            Frames.Add(new SquaresReplayFrame());

            foreach (SquaresHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new SquaresReplayFrame
                {
                    Time = hitObject.StartTime,
                    Position = hitObject.IndexToPosition(hitObject.Index),
                    // todo: add required inputs and extra frames.
                });
            }
        }
    }
}

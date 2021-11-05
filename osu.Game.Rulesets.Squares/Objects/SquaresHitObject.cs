// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using osuTK;

namespace osu.Game.Rulesets.Squares.Objects
{
    public class SquaresHitObject : HitObject
    {
        public override Judgement CreateJudgement() => new Judgement();

        public int Index { get; set; }

        public Vector2 IndexToPosition(int index)
        {
            Vector2 pos = new Vector2(480 * 0.05f / 3 / 2); // offset thing
            Vector2 squareX = new Vector2(480 / 3, 0);
            Vector2 squareY = new Vector2(0, 480 / 3);
            switch (index)
            {
                case 1:
                case 4:
                case 7:
                    pos += squareX;
                    break;
                case 2:
                case 5:
                case 8:
                    pos += 2 * squareX;
                    break;
                default:
                    break;
            }
            switch (index)
            {
                case 3:
                case 4:
                case 5:
                    pos += squareY;
                    break;
                case 6:
                case 7:
                case 8:
                    pos += 2 * squareY;
                    break;
                default:
                    break;
            }
            return pos;
        }
    }
}

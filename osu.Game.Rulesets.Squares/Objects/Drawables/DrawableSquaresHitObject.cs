// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Utils;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;
using System;

namespace osu.Game.Rulesets.Squares.Objects.Drawables
{
    public class DrawableSquaresHitObject : DrawableHitObject<SquaresHitObject>, IKeyBindingHandler<SquaresAction>
    {
        private const double time_preempt = 1000;

        // so mania does it with like a bindable thing... idk how that works... gonna go with something more primitive
        public SquaresAction Action { get; set; }

        public DrawableSquaresHitObject(SquaresHitObject hitObject)
            : base(hitObject)
        {
            Size = new Vector2((480 / 3) * 0.95f);
            Origin = Anchor.Centre;

            Position = hitObject.IndexToPosition(hitObject.Index);

            Action = (SquaresAction)hitObject.Index;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(new Box
            {
                RelativeSizeAxes = Axes.Both
            });
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (!userTriggered)
            {
                if (!HitObject.HitWindows.CanBeHit(timeOffset))
                    ApplyResult(r => r.Type = r.Judgement.MinResult);
                return;
            }

            var result = HitObject.HitWindows.ResultFor(timeOffset);
            if (result == HitResult.None || result == HitResult.Miss && Time.Current < HitObject.StartTime)
                return;

            ApplyResult(r => r.Type = result);
        }

        protected override double InitialLifetimeOffset => time_preempt;

        // lol they scale out from the top left but whatever
        protected override void UpdateInitialTransforms() => this.ScaleTo(0).Then().ScaleTo(1, time_preempt, Easing.In);

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
            const double duration = 100;

            switch (state)
            {
                case ArmedState.Hit:
                    this.FadeOut(duration, Easing.OutQuint).Expire();
                    break;

                case ArmedState.Miss:
                    this.FadeColour(Color4.Red, duration);
                    this.FadeOut(duration, Easing.InQuint).Expire();
                    break;
            }
        }

        public bool OnPressed(KeyBindingPressEvent<SquaresAction> e)
        {
            if (e.Action != Action)
                return false;
            return UpdateResult(true);
        }

        public void OnReleased(KeyBindingReleaseEvent<SquaresAction> e)
        {
        }
    }
}

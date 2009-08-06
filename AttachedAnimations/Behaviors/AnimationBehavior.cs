using System.Windows;
using System.Windows.Media.Animation;

namespace AttachedAnimations.Behaviors
{
    public static class AnimationBehavior
    {
        public static readonly DependencyProperty AnimateProperty = DependencyProperty.RegisterAttached("Animate",
                                                                                                        typeof (bool),
                                                                                                        typeof (
                                                                                                            AnimationBehavior
                                                                                                            ),
                                                                                                        new FrameworkPropertyMetadata
                                                                                                            (OnAnimateChange));

        public static readonly DependencyProperty StoryboardProperty = DependencyProperty.RegisterAttached("Storyboard",
                                                                                                           typeof (
                                                                                                               Storyboard
                                                                                                               ),
                                                                                                           typeof (
                                                                                                               AnimationBehavior
                                                                                                               ));

        private static void OnAnimateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var storyboard = GetStoryboard(d);
            var frameworkElement = d as FrameworkElement;

            if (storyboard == null || frameworkElement == null)
                return;

            var animate = GetAnimate(d);

            if (animate)
            {
                storyboard.Begin(frameworkElement);
            }
            else
            {
                storyboard.Stop(frameworkElement);
            }
        }

        public static Storyboard GetStoryboard(DependencyObject o)
        {
            return o.GetValue(StoryboardProperty) as Storyboard;
        }

        public static void SetStoryboard(DependencyObject o, Storyboard value)
        {
            o.SetValue(StoryboardProperty, value);
        }

        public static bool GetAnimate(DependencyObject o)
        {
            return (bool)o.GetValue(AnimateProperty);
        }

        public static void SetAnimate(DependencyObject o, bool value)
        {
            o.SetValue(AnimateProperty, value);
        }
    }
}
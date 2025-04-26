using Avalonia.Animation;
using Sekota_McLauncher.Animations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekota_McLauncher.Helpers
{
    public class AnimationHelper(List<BaseAnimations> animations)
    {
        public List<BaseAnimations> Animations { get; set; } = animations;
        public List<Task> Tasks { get; } = [];
        public bool Loopable { get; set; } = false;

        public AnimationHelper() : this([]) { }

        public async Task RunAsync()
        {
            do
            {
                Tasks.Clear();

                await RunAsyncCore();
            } while (Loopable);
        }

        private async Task RunAsyncCore()
        {
            // 根据 Wait 进行动画分组
            var groupedAnimations = new List<List<IAnimations>>();
            var currentGroup = new List<IAnimations>();
            foreach (var animation in Animations)
            {
                if (animation.Wait && currentGroup.Count > 0)
                {
                    groupedAnimations.Add(currentGroup);
                    currentGroup.Clear();
                    continue;
                }

                currentGroup.Add(animation);
            }

            if (currentGroup.Count > 0)
            {
                groupedAnimations.Add(currentGroup);
            }

            foreach (var list in groupedAnimations)
            {
                foreach (var animation in list)
                {
                    Tasks.Add(animation.RunAsync());
                }

                await Task.WhenAll(Tasks);
            }
        }

        public void Cancel() => Animations.ForEach(it => it.Cancel());

        public void Clear()
        {
            Cancel();
            Animations.Clear();
        }
    }
}

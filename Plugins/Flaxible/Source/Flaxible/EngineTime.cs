using FlaxEngine;
using System.Threading;
using System.Threading.Tasks;

namespace Game;

public static class EngineTime
{
    private static bool IsPaused { get; set; } = false;

    public static Task Delay(int frames, CancellationToken cancellationToken)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();

        var counter = 0;
        void OnFixedUpdate()
        {
            if (!IsPaused)
            {
                counter++;
            }

            if (counter >= frames)
            {
                Scripting.FixedUpdate -= OnFixedUpdate;
                taskCompletionSource.SetResult(true);
            }

            if (cancellationToken.IsCancellationRequested)
            {
                Scripting.FixedUpdate -= OnFixedUpdate;
                taskCompletionSource.SetCanceled();
            }
        }
        Scripting.FixedUpdate += OnFixedUpdate;

        return taskCompletionSource.Task;
    }
}

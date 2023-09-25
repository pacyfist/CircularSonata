using FlaxEngine;
using System;

namespace Flaxible;

public class FlaxibleModule : GamePlugin
{
    public FlaxibleModule()
    {
        _description = new PluginDescription
        {
            Name = "Flaxible Plugin",
            Category = "Other",
            Author = "Pacyfist",
            AuthorUrl = null,
            HomepageUrl = null,
            RepositoryUrl = "https://github.com/Pacyfist/FlaxiblePlugin",
            Description = "This is a library of Flax extensions used for async game development.",
            Version = new Version(0, 0, 1),
            IsAlpha = true,
            IsBeta = false,
        };
    }
}
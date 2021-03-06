﻿using NzbDrone.Core.Messaging.Commands;
using NzbDrone.Core.Messaging.Events;
using NzbDrone.Core.Tv.Commands;
using NzbDrone.Core.Tv.Events;

namespace NzbDrone.Core.Tv
{
    public class MovieAddedHandler : IHandle<MovieAddedEvent>
    {
        private readonly IManageCommandQueue _commandQueueManager;

        public MovieAddedHandler(IManageCommandQueue commandQueueManager)
        {
            _commandQueueManager = commandQueueManager;
        }

        public void Handle(MovieAddedEvent message)
        {
            _commandQueueManager.Push(new RefreshMovieCommand(message.Movie.Id));
        }
    }
}

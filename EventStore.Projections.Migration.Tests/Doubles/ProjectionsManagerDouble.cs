using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Projections;
using EventStore.ClientAPI.SystemData;

namespace EventStore.Projections.Migration.Tests.Doubles
{
    public class ProjectionsManagerDouble : ProjectionsManager
    {
        public ProjectionsManagerDouble(ILogger log, IPEndPoint httpEndPoint, TimeSpan operationTimeout) : base(log, httpEndPoint, operationTimeout)
        {
        }

        public new virtual Task CreateContinuousAsync(string name, string query, UserCredentials userCredentials = null)
        {
            return base.CreateContinuousAsync(name, query, userCredentials);
        }

        public new virtual Task CreateContinuousAsync(string name, string query, bool trackEmittedStreams, UserCredentials userCredentials = null)
        {
            return base.CreateContinuousAsync(name, query, trackEmittedStreams, userCredentials);
        }

        public new virtual Task EnableAsync(string name, UserCredentials userCredentials = null)
        {
            return base.EnableAsync(name, userCredentials);
        }

        public new virtual Task<List<ProjectionDetails>> ListAllAsync(UserCredentials userCredentials = null)
        {
            return base.ListAllAsync(userCredentials);
        }

        public virtual Task UpdateQueryAsync(string name, string query, bool emitEnabled = true, UserCredentials userCredentials = null)
        {
            return base.UpdateQueryAsync(name, query, emitEnabled, userCredentials);
        }
    }
}

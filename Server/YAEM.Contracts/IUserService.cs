// -----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Domain;

    /// <summary>
    /// The user service.
    /// </summary>
    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IServiceCallback))]
    public interface IUserService
    {
        /// <summary>
        /// Joins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The session of the joined user.</returns>
        [OperationContract]
        Session Join(User user);

        /// <summary>
        /// Leaves the specified session.
        /// </summary>
        /// <param name="session">The session.</param>
        [OperationContract(IsOneWay = true)]
        void Leave(Session session);

        /// <summary>
        /// Determines whether the specified session is joined.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>
        ///   <c>true</c> if the specified session is joined; otherwise, <c>false</c>.
        /// </returns>
        [OperationContract]
        bool IsJoined(Session session);

        /// <summary>
        /// Gets the joined users.
        /// </summary>
        /// <returns>Returns all joined users.</returns>
        [OperationContract]
        IEnumerable<User> GetJoinedUsers();

        /// <summary>
        /// Subscribes this instance.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Subscribe();

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Unsubscribe();
    }
}

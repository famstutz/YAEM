// -----------------------------------------------------------------------
// <copyright file="IMessagingService.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace YAEM.Contracts
{
    using System.ServiceModel;
    using Domain;

    /// <summary>
    /// The messaging service.
    /// </summary>
    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IServiceCallback))]
    public interface IMessagingService
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender.</param>
        [OperationContract(IsOneWay = true)]
        void Send(Message message, Session sender);
    }
}
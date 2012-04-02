// -----------------------------------------------------------------------
// <copyright file="IMessagingService.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using YAEM.Crypto;

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

        /// <summary>
        /// Negotiates the initialization vector.
        /// </summary>
        /// <param name="initializationVector">The initializatino vector.</param>
        /// <param name="algorithm">The algorithm.</param>
        [OperationContract(IsOneWay = true)]
        void NegotiateInitializationVector(byte[] initializationVector, CryptoAlgorithm algorithm);

        /// <summary>
        /// Negotiates the initialization vector.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="algorithm">The algorithm.</param>
        [OperationContract(IsOneWay = true)]
        void NegotiateKey(byte[] key, CryptoAlgorithm algorithm);
    }
}
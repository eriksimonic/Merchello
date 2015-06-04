﻿namespace Merchello.Core.Marketing.Offer
{
    using System;

    using Merchello.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// Marker interface for an offer.
    /// </summary>
    public interface IOffer
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <remarks>
        /// This is actually a reference to the OfferSettings key
        /// </remarks>
        Guid Key { get; }

        /// <summary>
        /// Gets or sets the offer provider key.
        /// </summary>
        Guid OfferProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the offer code.
        /// </summary>
        string OfferCode { get; set; }

        /// <summary>
        /// Gets or sets the offer starts date.
        /// </summary>
        DateTime OfferStartsDate { get; set; }

        /// <summary>
        /// Gets or sets the offer ends date.
        /// </summary>
        DateTime OfferEndsDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the offer is active.
        /// </summary>
        bool Active { get; set; }


        /// <summary>
        /// Attempts to award the reward defined by the offer
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <typeparam name="T">
        /// The type of offer award
        /// </typeparam>
        /// <returns>
        /// The <see cref="Attempt{IOfferAwardResult}"/>.
        /// </returns>
        Attempt<IOfferAwardResult<T>> TryToAward<T>(ICustomerBase customer) where T : class;

        /// <summary>
        /// Attempts to award the reward defined by the offer
        /// </summary>
        /// <param name="constraintBy">
        /// An object passed to the offer constraints.
        /// </param>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <typeparam name="T">
        /// The type of offer award
        /// </typeparam>
        /// <returns>
        /// The <see cref="Attempt{IOfferAwardResult}"/>.
        /// </returns>
        Attempt<IOfferAwardResult<T>> TryToAward<T>(object constraintBy, ICustomerBase customer) where T : class;

        /// <summary>
        /// Attempts to award the reward defined by the offer
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt"/>.
        /// </returns>
        Attempt<IOfferAwardResult<object>> TryToAward(ICustomerBase customer);

        /// <summary>
        /// Attempts to award the reward defined by the offer
        /// </summary>
        /// <param name="constrainBy">
        /// The constrain by.
        /// </param>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt"/>.
        /// </returns>
        Attempt<IOfferAwardResult<object>> TryToAward(object constrainBy, ICustomerBase customer);
    }
}